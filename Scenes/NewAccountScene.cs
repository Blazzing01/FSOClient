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
                Game.GraphicsDevice.Viewport.Height / 2f - 210),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 350), ImGuiCond.Always);

            ImGui.Begin("Create Account", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Create New Account");
            ImGui.Spacing();

            float windowWidth = ImGui.GetWindowWidth();
            float itemWidth = 250f;
            float offset = (windowWidth - itemWidth - 16) / 2f;

            // Email Label
            var emailTextSize = ImGui.CalcTextSize("Email");
            ImGui.SetCursorPosX(offset + (itemWidth - emailTextSize.X) / 2f);
            ImGui.Text("Email");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##email", ref _email, 64);

            ImGui.Spacing();

            // Password Label
            var passwordTextSize = ImGui.CalcTextSize("Password");
            ImGui.SetCursorPosX(offset + (itemWidth - passwordTextSize.X) / 2f);
            ImGui.Text("Password");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##password", ref _password, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();

            // Confirm Password Label
            var confirmPasswordTextSize = ImGui.CalcTextSize("Confirm Password");
            ImGui.SetCursorPosX(offset + (itemWidth - confirmPasswordTextSize.X) / 2f);
            ImGui.Text("Confirm Password");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##confirmPassword", ref _confirmPassword, 32, ImGuiInputTextFlags.Password);

            ImGui.Spacing();
            ImGui.Spacing();
            ImGui.Spacing();

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            if (ImGui.Button("Create Account", new System.Numerics.Vector2(itemWidth, 40)))
            {
                // TODO: Implement account creation logic
            }

            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            if (ImGui.Button("Back", new System.Numerics.Vector2(itemWidth, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }
    }
}
