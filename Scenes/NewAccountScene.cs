using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class NewAccountScene : BaseScene
    {
        private string _username = "";
        private string _email = "";
        private string _password = "";
        private string _confirmPassword = "";

        public NewAccountScene(Game game) : base(game)
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
                Game.GraphicsDevice.Viewport.Height / 2f - 150),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 320), ImGuiCond.Always);

            ImGui.Begin("Create Account", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Create New Account");
            ImGui.Spacing();

            ImGui.Text("Username");
            ImGui.InputText("##username", ref _username, 32);

            ImGui.Spacing();

            ImGui.Text("Email");
            ImGui.InputText("##email", ref _email, 64);

            ImGui.Spacing();

            ImGui.Text("Password");
            ImGui.InputText("##password", ref _password, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();

            ImGui.Text("Confirm Password");
            ImGui.InputText("##confirmPassword", ref _confirmPassword, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();

            if (ImGui.Button("Create Account", new System.Numerics.Vector2(-1, 40)))
            {
                // TODO: Implement account creation logic
            }

            if (ImGui.Button("Back", new System.Numerics.Vector2(-1, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
