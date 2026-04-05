using FSOClient.Scenes;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.ImGui.Standard;
using System;
using System.IO;
using System.Reflection;

namespace FSOClient
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly ScreenManager _screenManager;
        public ImGUIRenderer GuiRenderer;
        public ScreenManager ScreenManager => _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            GuiRenderer = new ImGUIRenderer(this).Initialize();
            LoadSystemFont();
            GuiRenderer.RebuildFontAtlas();
            var io = ImGui.GetIO();
            io.WantSaveIniSettings = false;

            // Disable anti-aliased lines
            var style = ImGui.GetStyle();
            style.AntiAliasedLines = false;
            style.WindowRounding = 12f;
            style.FrameRounding = 6f;
            style.FrameBorderSize = 1f;

            _screenManager.ShowScreen(new Loadingscene(this));

        }

        private void LoadSystemFont()
        {
            try
            {
                var io = ImGui.GetIO();
                io.Fonts.Clear();

                // Enable pixel snapping for sharper rendering
                io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;

                string fontsPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

                // Try Segoe UI first (modern, renders better in ImGui)
                string segoeUiPath = Path.Combine(fontsPath, "segoeui.ttf");
                if (File.Exists(segoeUiPath))
                {
                    io.Fonts.AddFontFromFileTTF(segoeUiPath, 24);
                }
                else
                {
                    // Fallback to Verdana
                    string verdanaPath = Path.Combine(fontsPath, "verdana.ttf");
                    if (File.Exists(verdanaPath))
                    {
                        io.Fonts.AddFontFromFileTTF(verdanaPath, 24);
                    }
                    else
                    {
                        // Final fallback: use Arial
                        string arialPath = Path.Combine(fontsPath, "arial.ttf");
                        if (File.Exists(arialPath))
                        {
                            io.Fonts.AddFontFromFileTTF(arialPath, 24);
                        }
                    }
                }

                io.Fonts.Build();
                GuiRenderer.RebuildFontAtlas();

                // Set global scale to 0.99 for pixel-perfect font rendering (avoids wavy text at 1.0 scale)
                io.FontGlobalScale = 0.99f;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load font: {ex.Message}");
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Single BeginLayout/EndLayout wraps all ImGui rendering
            if (GuiRenderer != null)
            {
                GuiRenderer.BeginLayout(gameTime);

                // Let the screen manager (scenes) render their ImGui
                base.Draw(gameTime);

                // Render demo window on top
                ImGui.ShowDemoWindow();

                GuiRenderer.EndLayout();
            }
            else
            {
                // Fallback if renderer isn't ready
                base.Draw(gameTime);
            }

            // TODO: Add your drawing code here
        }
    }
}
