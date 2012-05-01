// CommandHelper.cs
// This class implements some useful methods that help building command bars and adding commands.
// Copyright by Matthias Hertel, http://www.mathertel.de
// This work is licensed under a Creative Commons Attribution 2.0 Germany License.
// See http://creativecommons.org/licenses/by/2.0/de/
// ----- 
// 31.01.2006 created by Matthias Hertel
// 17.03.2006 some dead code deleted.

// hints on using icons, see: http://blogs.msdn.com/hlong/default.aspx; http://blogs.msdn.com/hlong/archive/2005/09/27/474522.aspx

using System;
using System.Diagnostics;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;


namespace Zippy.Chirp
{
     /// <summary>A class with static methods for building and managing commands in a host.</summary>
        public class CommandHelper
        {

            /// <summary>
            /// Create a new Command Bar and remove the existing Command Bar with the same name.
            /// </summary>
            /// <param name="applicationObject">The host application.</param>
            /// <param name="szName">The name of the new command bar.</param>
            /// <returns>The created CommandaBar object.</returns>
            public static CommandBar AddCommandBar(DTE2 applicationObject, String szName)
            {
                Commands commands = applicationObject.Commands;
                CommandBar cmdBar = null;

                try
                {
                    CommandBars oldCmdBars = (CommandBars)applicationObject.CommandBars;
                    CommandBar oldCmdBar = oldCmdBars[szName];
                    commands.RemoveCommandBar(oldCmdBar);
                }
                catch (ArgumentException)
                {
                    // Thrown if command doesn't already exist.
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.AddCommandBar");
                } // try

                try
                {
                    cmdBar = (CommandBar)commands.AddCommandBar(szName, vsCommandBarType.vsCommandBarTypeToolbar, null, 0);
                }
                catch (ArgumentException)
                {
                    // Thrown if command doesn't already exist.
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.AddCommandBar");
                } // try
                return (cmdBar);
            } // AddCommandBar


            /// <summary>Add one of the commands, dealing with the errors that might result.</summary>
            /// <remarks>First version from MSDN Magazin 02/02</remarks>
            /// <param name="applicationObject">The host application.</param>
            /// <param name="addInInstance"></param>
            /// <param name="szName">name of the command being added</param>
            /// <param name="IconNr">Number of the corresponding icon in the resource dll.</param>
            /// <param name="szButtonText">text displayed on menu or button</param>
            /// <param name="szToolTip">text displayed in tool tip</param>
            /// <param name="szKey">default key assignment, or empty string if none</param>
            /// <param name="CmdBars">optional CommandBars where this command should be added.</param>
            public static Command AddCommand(DTE2 applicationObject, AddIn addInInstance,
                                             String szName, int IconNr, String szButtonText, String szToolTip, String szKey,
                                             params CommandBar[] CmdBars)
            {
                Command cmd = null;
                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)applicationObject.Commands;

                // The IDE identifies commands by their full name, which include the add-in name
                try
                {
                    cmd = commands.Item("Zippy.Chirp." + szName, -1);
                    cmd.Delete();
                }
                catch (ArgumentException)
                {
                    // Thrown if command doesn't already exist.
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.AddCommand");
                } // try

                // The IDE in Visual Studio8 identifies commands by their full name, which include the add-in name
                try
                {
                    cmd = commands.Item("Zippy.Chirp.Chirp." + szName, -1);
                    cmd.Delete();
                }
                catch (ArgumentException)
                {
                    // Thrown if command doesn't already exist.
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.AddCommand");
                } // try

                try
                {
                    // Icons from the satelite dll.
                    cmd = commands.AddNamedCommand2(addInInstance, szName, szButtonText, szToolTip,
                                                    false, IconNr, ref contextGUIDS,
                                                    (int)vsCommandStatus.vsCommandStatusSupported +
                                                    (int)vsCommandStatus.vsCommandStatusEnabled,
                                                                                    (int)vsCommandStyle.vsCommandStylePictAndText,
                                                                                    vsCommandControlType.vsCommandControlTypeButton);
                }
                catch (ArgumentException exArg)
                {
                    // Thrown if command already exist.
                    Debug.WriteLine(exArg.Message, "ChirpyPopupAddIn.AddCommand");
                    //System.Windows.Forms.MessageBox.Show("AddCommand=" + exArg.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.AddCommand");
                    //System.Windows.Forms.MessageBox.Show("AddCommand=" + ex.ToString());
                } // try

                if ((szKey != null) && (szKey != ""))
                {
                    // a default keybinding specified
                    object[] bindings;
                    bindings = (object[])cmd.Bindings;
                    if (0 >= bindings.Length)
                    {
                        // there is no preexisting key binding, so add the default
                        bindings = new object[1];
                        bindings[0] = (object)szKey;
                        cmd.Bindings = (object)bindings;
                    } // if
                } // if

                // Append Control at end of CommandBar
                foreach (CommandBar c in CmdBars)
                {
                    if (c != null)
                        cmd.AddControl(c, c.Controls.Count + 1);
                } // foreach
                return (cmd);
            } // AddCommand


            /// <summary>
            /// Remove the registration for a command.
            /// </summary>
            /// <param name="applicationObject">The host application.</param>
            /// <param name="commandName"></param>
            public static void RemoveCommand(DTE2 applicationObject, string commandName)
            {
                try
                {
                    Command cmd = applicationObject.Commands.Item(commandName, -1);
                    if (cmd != null) cmd.Delete();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.RemoveCommand");
                } // try
            } // RemoveCommand


            /// <summary>
            /// Remove a Control from a CommnandBar
            /// </summary>
            /// <param name="applicationObject">The host application.</param>
            /// <param name="commandBarName"></param>
            /// <param name="controlName"></param>
            public static void RemoveCommandControl(DTE2 applicationObject, string commandBarName, string controlName)
            {
                // Remove the controls from the CommandBars
                try
                {
                    CommandBars cmdBars = (CommandBars)(applicationObject.CommandBars);
                    CommandBar bar = cmdBars[commandBarName];
                    CommandBarControl ctrl = null;
                    for (int n = 1; n <= bar.Controls.Count; n++)
                    {
                        string cap = bar.Controls[n].Caption;
                        if (bar.Controls[n].Caption == controlName)
                            ctrl = bar.Controls[n];
                    } // for
                    // CommandBarControl ctrl = bar.Controls[controlName];
                    if (ctrl != null) ctrl.Delete(false);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ChirpyPopupAddIn.RemoveCommandControl");
                } // try
            } // RemoveCommandControl
        }

}
