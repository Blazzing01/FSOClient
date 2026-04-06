using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSOClient.Scenes
{
    internal class CharacterSelectionScene : BaseScene
    {
        private class CharacterSlot
        {
            public string Name { get; set; } = "Empty";
            public string Level { get; set; } = "---";
            public bool IsEmpty { get; set; } = true;
        }

        private CharacterSlot[] _characters = new CharacterSlot[5];
        private int _selectedCharacterIndex = -1;
        private bool SelectingCharacter = true;

        // Character Creation Fields
        private string _newCharacterName = "";
        private int _selectedClass = 0;
        private string[] _classes = { "Warrior", "Mage", "Rogue", "Ranger", "Paladin" };
        private int _selectedGender = 0;
        private string[] _genders = { "Male", "Female" };
        private int _selectedSkinTone = 0;
        private string[] _skinTones = { "Fair", "Medium", "Dark" };

        public CharacterSelectionScene(Game game) : base(game)
        {
            // Initialize character slots
            for (int i = 0; i < _characters.Length; i++)
            {
                _characters[i] = new CharacterSlot();
            }
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
            if (SelectingCharacter)
            {
                RenderCharacterSelection();
            }
            else
            {
                RenderCharacterCreation();
            }
        }

        private void RenderCharacterSelection()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(
            Game.GraphicsDevice.Viewport.Width / 2f - 450 / 2f,
            Game.GraphicsDevice.Viewport.Height / 2f - 500 / 2f),
            ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(450, 500), ImGuiCond.Always);

            ImGui.Begin("Character Selection", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Select Your Character");
            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            float windowWidth = ImGui.GetWindowWidth();
            float slotWidth = 380f;
            float slotOffset = (windowWidth - slotWidth - 16) / 2f;

            // Render 5 character slots
            for (int i = 0; i < 5; i++)
            {
                ImGui.SetCursorPosX(slotOffset);

                // Character slot button
                string slotLabel = _characters[i].IsEmpty ?
                    $"[Empty Slot {i + 1}]" :
                    $"{_characters[i].Name} (Lvl {_characters[i].Level})";

                bool isSelected = _selectedCharacterIndex == i;
                if (isSelected)
                {
                    ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.2f, 0.4f, 0.8f, 1f));
                }

                ImGui.SetNextItemWidth(slotWidth);
                if (ImGui.Button(slotLabel, new System.Numerics.Vector2(slotWidth, 45)))
                {
                    _selectedCharacterIndex = i;
                }

                if (isSelected)
                {
                    ImGui.PopStyleColor();
                }

                ImGui.Spacing();
            }

            ImGui.Separator();
            ImGui.Spacing();

            // Action buttons
            ImGui.SetCursorPosX(slotOffset);
            ImGui.SetNextItemWidth(slotWidth / 2 - 5);
            if (ImGui.Button("Create New", new System.Numerics.Vector2((slotWidth / 2) - 5, 40)))
            {
                if (_selectedCharacterIndex >= 0)
                {
                    SelectingCharacter = false;
                    ResetCharacterCreation();
                }
            }

            ImGui.SameLine();

            ImGui.SetNextItemWidth(slotWidth / 2 - 5);
            if (ImGui.Button("Delete", new System.Numerics.Vector2((slotWidth / 2) - 5, 40)))
            {
                if (_selectedCharacterIndex >= 0)
                {
                    _characters[_selectedCharacterIndex] = new CharacterSlot();
                    _selectedCharacterIndex = -1;
                }
            }

            ImGui.Spacing();

            ImGui.SetCursorPosX(slotOffset);
            ImGui.SetNextItemWidth(slotWidth);
            if (_selectedCharacterIndex >= 0 && !_characters[_selectedCharacterIndex].IsEmpty)
            {
                if (ImGui.Button("Enter World", new System.Numerics.Vector2(slotWidth, 40)))
                {
                    // TODO: Implement entering game world
                }
            }
            else if (_selectedCharacterIndex >= 0 && _characters[_selectedCharacterIndex].IsEmpty)
            {
                if (ImGui.Button("Create Character", new System.Numerics.Vector2(slotWidth, 40)))
                {
                    SelectingCharacter = false;
                    ResetCharacterCreation();
                }
            }

            ImGui.Spacing();

            ImGui.SetCursorPosX(slotOffset);
            ImGui.SetNextItemWidth(slotWidth);
            if (ImGui.Button("Back", new System.Numerics.Vector2(slotWidth, 40)))
            {
                Game1.ScreenManager.ShowScreen(new Menuscene(Game));
            }

            ImGui.End();
        }

        private void RenderCharacterCreation()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(
                Game.GraphicsDevice.Viewport.Width / 2f - 400 / 2f,
                Game.GraphicsDevice.Viewport.Height / 2f - 480 / 2f),
                ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(400, 480), ImGuiCond.Always);

            ImGui.Begin("Create Character", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar);

            ImGui.Text("Character Creation");
            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            float windowWidth = ImGui.GetWindowWidth();
            float itemWidth = 320f;
            float offset = (windowWidth - itemWidth - 16) / 2f;

            // Character Name
            var nameTextSize = ImGui.CalcTextSize("Character Name");
            ImGui.SetCursorPosX(offset + (itemWidth - nameTextSize.X) / 2f);
            ImGui.Text("Character Name");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.InputText("##charName", ref _newCharacterName, 32);

            ImGui.Spacing();

            // Class Selection
            var classTextSize = ImGui.CalcTextSize("Select Class");
            ImGui.SetCursorPosX(offset + (itemWidth - classTextSize.X) / 2f);
            ImGui.Text("Select Class");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.Combo("##classSelect", ref _selectedClass, _classes, _classes.Length);

            ImGui.Spacing();

            // Gender Selection
            var genderTextSize = ImGui.CalcTextSize("Gender");
            ImGui.SetCursorPosX(offset + (itemWidth - genderTextSize.X) / 2f);
            ImGui.Text("Gender");
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth);
            ImGui.Combo("##genderSelect", ref _selectedGender, _genders, _genders.Length);

            ImGui.Spacing();
            ImGui.Spacing();

            // Create Button
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(itemWidth / 2 - 5);
            if (ImGui.Button("Create", new System.Numerics.Vector2((itemWidth / 2) - 5, 40)))
            {
                if (!string.IsNullOrWhiteSpace(_newCharacterName) && _selectedCharacterIndex >= 0)
                {
                    _characters[_selectedCharacterIndex].Name = _newCharacterName;
                    _characters[_selectedCharacterIndex].Level = "1";
                    _characters[_selectedCharacterIndex].IsEmpty = false;
                    SelectingCharacter = true;
                    ResetCharacterCreation();
                }
            }

            ImGui.SameLine();

            // Cancel Button
            ImGui.SetNextItemWidth(itemWidth / 2 - 5);
            if (ImGui.Button("Cancel", new System.Numerics.Vector2((itemWidth / 2) - 5, 40)))
            {
                SelectingCharacter = true;
                ResetCharacterCreation();
            }

            ImGui.End();
        }

        private void ResetCharacterCreation()
        {
            _newCharacterName = "";
            _selectedClass = 0;
            _selectedGender = 0;
            _selectedSkinTone = 0;
        }
    }
}
