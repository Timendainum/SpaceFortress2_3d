using System;
using ClientWindowsGameLibrary.ScreenManagement;
using ThreeDWindowsGameLibrary.Simulation;
using Microsoft.Xna.Framework;

namespace SpaceFortress2.Screens
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	public class MainMenuScreen : MenuScreen
	{
		#region Initialization


		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen()
			: base("Main Menu")
		{
			// Create our menu entries.
			MenuEntry playSinglePlayerGameMenuEntry = new MenuEntry("Play Single Player");
			MenuEntry optionsMenuEntry = new MenuEntry("Options");
			MenuEntry exitMenuEntry = new MenuEntry("Exit");

			// Hook up menu event handlers.
			playSinglePlayerGameMenuEntry.Selected += PlayGameMenuEntrySelected;
			optionsMenuEntry.Selected += OptionsMenuEntrySelected;
			exitMenuEntry.Selected += OnCancel;

			// Add entries to the menu.
			MenuEntries.Add(playSinglePlayerGameMenuEntry);
			MenuEntries.Add(optionsMenuEntry);
			MenuEntries.Add(exitMenuEntry);
		}
		#endregion

		#region Handle Input


		/// <summary>
		/// Event handler for when the Play Game menu entry is selected.
		/// </summary>
		void PlayGameMenuEntrySelected(object sender, EventArgs e)
		{
			GameStateManager.StartGame();

			LoadingScreen.Load(ScreenManager, true, new TacticalScreen());
		}


		/// <summary>
		/// Event handler for when the Options menu entry is selected.
		/// </summary>
		void OptionsMenuEntrySelected(object sender, EventArgs e)
		{
			ScreenManager.AddScreen(new OptionsMenuScreen());
		}


		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected override void OnCancel()
		{
			const string message = "Are you sure you want to exit?";

			MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

			confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

			ScreenManager.AddScreen(confirmExitMessageBox);
		}


		/// <summary>
		/// Event handler for when the user selects ok on the "are you sure
		/// you want to exit" message box.
		/// </summary>
		void ConfirmExitMessageBoxAccepted(object sender, EventArgs e)
		{
			GameStateManager.EndGame();
			ScreenManager.Game.Exit();
		}
		#endregion
	}
}
