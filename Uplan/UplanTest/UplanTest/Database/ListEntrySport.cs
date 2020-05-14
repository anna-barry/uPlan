using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest
{
    class ListEntrySport
    {
        public class ListEntryForFood
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }

            public static void Initiate()
            {
                // Get a collection (or create, if doesn't exist)
                var col = Database.db.GetCollection<ListEntry>("Abs1");

                col.Insert(new ListEntry { Type = "Abs1", Code = "JumpSquat", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "JumpingLunges", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "Punches", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "Plank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "Lunge", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "SideLunge", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "Squat", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "Scissors", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "LegRaise", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "RaisedCircle", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "JackKnives", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "RaisedSwing", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Abs3", Code = "CycleAbs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "ObliqueCrunch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "GlutBridges", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SidePlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "HipThruster", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "PlankTwist", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SideCrunchKick", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "Crunches", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SidePlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "Squat", Description = "mettrel'asset?" });


                col.Insert(new ListEntry { Type = "Abs4", Code = "BreakDancerReach", Description = "mettrel'asset?" }) ;
                col.Insert(new ListEntry { Type = "Abs4", Code = "ElbowPlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "MontainClimber", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "UpDownPlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ClutterBridge", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ToeTouch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "SideJack", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "RussianTwist", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Abs5", Code = "BicyleCrunch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Crunchs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Reverse", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Plank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "RussianTwist", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "CrossCrunch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "KneeCrunch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "LongArmCrunches", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "CrossLeg", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "OneArmToe", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Abs6", Code = "Crunchs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "CrossCrunchs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "LegUp", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "ToeTouch", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "Burpees", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "MontainClimbers", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "Plank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "ObliqueTwists", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "RightCrunchs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "SideCrunchs", Description = "mettrel'asset?" });


                col.Insert(new ListEntry { Type = "Arms1", Code = "WallPushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "ArmSwing", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "ArmCircle", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Burpees", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "JumpingJacks", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "TricepsDips", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Punchs", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "KneePushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Burpees", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "JumpingJacks", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Arms2", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PlankTaps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "TricepsDips", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "OverHeadPull", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "HammerCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "ShoulderPresses", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "ReverseFly", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PlankTaps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "TricepsDips", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmPlunge", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushAndStrech", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "Scissors", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmRotating", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "NamasteEx", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushAndPull", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "SidePlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "BicepsCurls", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmCircle", Description = "mettrel'asset?" });


                col.Insert(new ListEntry { Type = "Arms4", Code = "ChairPushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ClapHands", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ReverseFly", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "JumpingRope", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "TricepsDips", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "DumbelSideRaise", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "SidePlank", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ReverseFly", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "JumpingRope", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Arms5", Code = "BarbelCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "ConcentrationCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "HammerCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "ReverseCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "DipsCurl", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "SkullCrusher", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "CrushDown", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushUps", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushUpsClap", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushDowns", Description = "mettrel'asset?" });

                col.Insert(new ListEntry { Type = "Arms6", Code = "Dips", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "PushDown", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "Extensions", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "DumbellExtensions", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SeatedBarbell", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "OverheadBarbell", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SeatedExtension", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "ArmsCircles", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "ExtendedClench", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SideExtendedClench", Description = "mettrel'asset?" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "OverHeadClench", Description = "mettrel'asset?" });

            }
        }
    }
}
