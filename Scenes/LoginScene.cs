using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class LoginScene : BaseScene
    {
        private string _username = "";
        private string _password = "";

        public LoginScene(Game game) : base(game)
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
                Game.GraphicsDevice.Viewport.Height / 2f - 120),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 250), ImGuiCond.Always);

            ImGui.Begin("Login", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Welcome Back");
            ImGui.Spacing();
            ImGui.Spacing();

            ImGui.Text("Username");
            ImGui.InputText("##username", ref _username, 32);

            ImGui.Spacing();

            ImGui.Text("Password");
            ImGui.InputText("##password", ref _password, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();
            ImGui.Spacing();

            if (ImGui.Button("Login", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Implement login logic
            }

            if (ImGui.Button("Back", new System.Numerics.Vector2(-1, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
