using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ImGuiNET;

namespace FSOClient.Scenes
{
    internal class Loadingscene : BaseScene
    {
        private float _loadingProgress;
        private string _loadingText;
        private bool _isLoading;

        public Loadingscene(Game game) : base(game)
        {
            _loadingProgress = 0f;
            _loadingText = "Initializing...";
            _isLoading = true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_isLoading)
            {
                _loadingProgress += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;

                if (_loadingProgress >= 1f)
                {
                    _loadingProgress = 1f;
                    _loadingText = "Complete!";
                    _isLoading = false;
                    TransitionToMenu();
                }
                else if (_loadingProgress < 0.33f)
                {
                    _loadingText = "Loading assets...";
                }
                else if (_loadingProgress < 0.66f)
                {
                    _loadingText = "Initializing systems...";
                }
                else
                {
                    _loadingText = "Finalizing...";
                }
            }
        }

        private void TransitionToMenu()
        {
            // Use MonoGame.Extended ScreenManager to transition to the menu scene
            if (Game1?.ScreenManager != null)
            {
                // Show the menu screen - the loading screen will naturally stop being drawn
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }
        }

        protected override void RenderImGui(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(
                Game.GraphicsDevice.Viewport.Width / 2f - 200,
                Game.GraphicsDevice.Viewport.Height / 2f - 50),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(400, 100), ImGuiCond.Always);

            ImGui.Begin("Loading", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text(_loadingText);
            ImGui.ProgressBar(_loadingProgress, new System.Numerics.Vector2(-1, 0));

            ImGui.End();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void OnActivated()
        {
            base.OnActivated();
        }

        public override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
