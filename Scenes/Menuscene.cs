using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace FSOClient.Scenes
{
    internal class Menuscene : BaseScene
    {
        public Menuscene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }

        protected override void RenderImGui(GameTime gameTime)
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(
                Game.GraphicsDevice.Viewport.Width / 2f - 150,
                Game.GraphicsDevice.Viewport.Height / 2f - 100),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 300), ImGuiCond.Always);

            ImGui.Begin("Main Menu", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.NoTitleBar);

            if (ImGui.Button("Login", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Transition to game screen
                Game1.ScreenManager.ShowScreen(new LoginScene(Game1));
            }

            if (ImGui.Button("Create Account", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Transition to game screen
                Game1.ScreenManager.ShowScreen(new NewAccountScene(Game1));
            }

            if (ImGui.Button("Community", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Transition to settings screen
                Game1.ScreenManager.ShowScreen(new CommunityScene(Game1));
            }

            if (ImGui.Button("Settings", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Transition to settings screen
                Game1.ScreenManager.ShowScreen(new SettingScene(Game1));
            }

            if (ImGui.Button("Exit", new System.Numerics.Vector2(-1, 40)))
            {
                Game.Exit();
            }

            ImGui.End();
        }
    }
}
