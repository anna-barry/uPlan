using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UplanTest
{
        public class ListEntrySport

        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }

            public static void Initiate()
            {
                // Get a collection (or create, if doesn't exist)
                var col = Database.db.GetCollection<ListEntry>("ListEntries");

                //ABS__________________________________________________________________________________________________
                col.Insert(new ListEntry { Type = "Abs1", Code = "JumpSquat", Description = "Jump squat"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "PushUps", Description = "Pushups"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "JumpingLunges", Description = "Jumping lunges"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "Punches", Description = "Punches"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "Plank", Description = "Plank"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "Lunge", Description = "Lunge"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "SideLunge", Description = "Side lunge"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "Squat", Description = "Squat"});
                col.Insert(new ListEntry { Type = "Abs1", Code = "JumpSquat", Description = "Jump squat" });
                col.Insert(new ListEntry { Type = "Abs1", Code = "PushUps", Description = "Pushups" });


                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "Count hold" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "Scissors", Description = "Scissors" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "Count hold" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "LegRaise", Description = "Leg raise" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "RaisedCircle", Description = "Raised circle" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "JackKnives", Description = "Jack knives" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "RaisedSwing", Description = "Raised swing" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "Count hold" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "Scissors", Description = "Scissors" });
                col.Insert(new ListEntry { Type = "Abs2", Code = "CountHold", Description = "Count hold" });

                col.Insert(new ListEntry { Type = "Abs3", Code = "CycleAbs", Description = "Cycle abs" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "ObliqueCrunch", Description = "Oblique crunch" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "GlutBridges", Description = "Glut bridges" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SidePlank", Description = "Side plank" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "HipThruster", Description = "Hip thruster" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "PlankTwist", Description = "Plank twist" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SideCrunchKick", Description = "Side crunch kick" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "Crunches", Description = "Crunches" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "SidePlank", Description = "Side plank" });
                col.Insert(new ListEntry { Type = "Abs3", Code = "Squat", Description = "Squat" });


                col.Insert(new ListEntry { Type = "Abs4", Code = "BreakDancerReach", Description = "Break dancer reach" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ElbowPlank", Description = "Elbow plank" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "MontainClimber", Description = "Moutain climber" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "UpDownPlank", Description = "Updown plank" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ClutterBridge", Description = "Clutter bridge" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ToeTouch", Description = "Toe touch" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "SideJack", Description = "Side jack" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "RussianTwist", Description = "Russian twist" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "BreakDancerReach", Description = "Break dancer reach" });
                col.Insert(new ListEntry { Type = "Abs4", Code = "ElbowPlank", Description = "Elbow plank" });


                col.Insert(new ListEntry { Type = "Abs5", Code = "BicyleCrunch", Description = "Bycicle crunch" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Crunch", Description = "Crunch" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Reverse", Description = "Reverse" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "Plank", Description = "Plank" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "RussianTwist", Description = "Russian twist" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "CrossCrunch", Description = "Cross crunch" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "KneeCrunch", Description = "Knee crunch" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "LongArmCrunches", Description = "Long arm crunch" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "CrossLeg", Description = "Cross leg" });
                col.Insert(new ListEntry { Type = "Abs5", Code = "OneArmToe", Description = "One arm toe" });

                col.Insert(new ListEntry { Type = "Abs6", Code = "Crunch", Description = "Crunch" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "CrossCrunch", Description = "Cross crunch" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "LegUp", Description = "Leg up" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "ToeTouch", Description = "Toe touch" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "Burpees", Description = "Burpees" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "MontainClimbers", Description = "Moutain climbers" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "Plank", Description = "Plank" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "ObliqueTwists", Description = "Oblique twists" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "RightCrunchs", Description = "Right crunchs" });
                col.Insert(new ListEntry { Type = "Abs6", Code = "LeftCrunchs", Description = "Left crunchs" });

                //ARMS__________________________________________________________________________________________________

                col.Insert(new ListEntry { Type = "Arms1", Code = "WallPushUps", Description = "Wall push ups" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "ArmSwing", Description = "Arm swing" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "ArmCircle", Description = "Arm circle" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Burpees", Description = "Burpees" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "JumpingJacks", Description = "Jumping jacks" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "TricepsDips", Description = "Triceps dips" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Punchs", Description = "Punchs" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "KneePushUps", Description = "Knee push ups" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "Burpees", Description = "Burpees" });
                col.Insert(new ListEntry { Type = "Arms1", Code = "JumpingJacks", Description = "Jumping jacks" });

                col.Insert(new ListEntry { Type = "Arms2", Code = "PushUps", Description = "Push ups" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PlankTaps", Description = "¨Plank taps" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "TricepsDips", Description = "Triceps dips" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "OverHeadPull", Description = "Over head pull" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "HammerCurl", Description = "Hammer curl" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "ShoulderPresses", Description = "Shoulder presses" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "ReverseFly", Description = "Reverse fly" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PushUps", Description = "Push ups" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "PlankTaps", Description = "Plank taps" });
                col.Insert(new ListEntry { Type = "Arms2", Code = "TricepsDips", Description = "Triceps dips" });

                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmPlunge", Description = "Arm plunge" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushAndStrech", Description = "Push and strech" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "Scissors", Description = "Scissors" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmRotating", Description = "Arm rotating" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "NamasteEx", Description = "Namaste exercice" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushAndPull", Description = "Push and pull" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "PushUps", Description = "Push ups" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "SidePlank", Description = "Side plank" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "BicepsCurls", Description = "Biceps curls" });
                col.Insert(new ListEntry { Type = "Arms3", Code = "ArmCircle", Description = "Arm circle" });


                col.Insert(new ListEntry { Type = "Arms4", Code = "ChairPushUps", Description = "Chair push ups" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "PushUps", Description = "Push ups" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ClapHands", Description = "Hand clap" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ReverseFly", Description = "Reverse fly" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "JumpingRope", Description = "Jumping rope" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "TricepsDips", Description = "Triceps dips" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "DumbelSideRaise", Description = "Dumbel side raise" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "SidePlank", Description = "Side plank" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "ReverseFly", Description = "Revers fly" });
                col.Insert(new ListEntry { Type = "Arms4", Code = "JumpingRope", Description = "Jumping rope" });

                col.Insert(new ListEntry { Type = "Arms5", Code = "BarbelCurl", Description = "Barbel curl" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "ConcentrationCurl", Description = "Concentration curl" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "HammerCurl", Description = "Hammer curl" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "ReverseCurl", Description = "Reverse curl" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "DipsCurl", Description = "Dips curl" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "SkullCrusher", Description = "Skull crusher" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "CrushDown", Description = "Crush down" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushUps", Description = "Push ups" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushUpsClap", Description = "Clap push ups" });
                col.Insert(new ListEntry { Type = "Arms5", Code = "PushDowns", Description = "Push down" });

                col.Insert(new ListEntry { Type = "Arms6", Code = "Dips", Description = "Dips" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "PushDown", Description = "Push down" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "Extensions", Description = "Extensions" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "DumbellExtensions", Description = "Dumbell extensions" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SeatedBarbell", Description = "Seated barbell" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "OverheadBarbell", Description = "Overhead barbell" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SeatedExtension", Description = "Seated extension" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "ArmsCircles", Description = "Arms circle" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "ExtendedClench", Description = "Extended clench" });
                col.Insert(new ListEntry { Type = "Arms6", Code = "SideExtendedClench", Description = "Side extended clench" });

                //LEGS__________________________________________________________________________________________________

                col.Insert(new ListEntry { Type = "Legs1", Code = "TableTop", Description = "Table top" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Bridging", Description = "Bridging" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "PilateCrunch", Description = "Pilate crunch" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Dart", Description = "Dart" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "FrontBridge", Description = "Front bridges" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "The100", Description = "The 100" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "AirPlanning", Description = "Air planning" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "AlternateHeel", Description = "Alternate heel" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Crunchs", Description = "Crunchs" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "MontainClimber", Description = "Montain climber" });

                col.Insert(new ListEntry { Type = "Legs2", Code = "SumoSquat", Description = "Sumo squat" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "SideLegRaise", Description = "Side leg raise" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "DeepSideLunge", Description = "Deep side lunge" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "LegExtension", Description = "Leg extension" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "SideLegExtension", Description = "Side leg extension" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "SideLegRaise", Description = "Side leg raise" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "CrossOverExtension", Description = "Crossover extention" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "LyingLeftLift", Description = "Lying lift" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "Lunge", Description = "Lunge" });
                col.Insert(new ListEntry { Type = "Legs2", Code = "HipRaise", Description = "Hip raise" });

                col.Insert(new ListEntry { Type = "Legs3", Code = "FrogJump", Description = "Frog jump" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "SidePlank", Description = "Side plank" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "BulgarianSplit", Description = "Bulgarian split" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "BentOver", Description = "Bent over" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "SumoSquat", Description = "Sumo squat" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "OneLeggedRow", Description = "One legged row" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "PlieSquat", Description = "Plie squat" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "BentGlut", Description = "Bent glut" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "WallSquat", Description = "Wall squat" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "LatteralLunge", Description = "Latteral lunge" });


                col.Insert(new ListEntry { Type = "Legs4", Code = "LungeKick", Description = "Lunge kick" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "ButtLift", Description = "Butt lift" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "CrissCross", Description = "Criss cross" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "BootyPush", Description = "Booty push" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "Burpees", Description = "Burpees" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "GobletSquat", Description = "Goblet squat" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "Squat", Description = "Squat" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "JumpSquat", Description = "Jump squat" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "SideLunge", Description = "Side lunge" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "ButBridge", Description = "But bridge" });

                col.Insert(new ListEntry { Type = "Legs5", Code = "Squat", Description = "Squat" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "Lunges", Description = "Lunges" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "SideLunges", Description = "Side lunges" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "CalfRaise", Description = "Claf raise" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "LegStraight", Description = "Leg straight raise" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "PullOver", Description = "Pull over" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "BigCurl", Description = "Big curl" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "SquatJumps", Description = "Squat jumps" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "Swing", Description = "Swing" });
                col.Insert(new ListEntry { Type = "Legs5", Code = "SplitLunges", Description = "Split lunges" });

                col.Insert(new ListEntry { Type = "Legs6", Code = "StandingLegAbduction", Description = "Standing leg abduction" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "StandingHipExtension", Description = "Standing hip extension" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "SeatingBicepCurls", Description = "Seating bicep curls" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "StandingCurls", Description = "Standing curls" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "OverheadPush", Description = "Overhead push" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "LyingLegAbduction", Description = "Lying leg abduction" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "LegCurlProne", Description = "Leg curl prone" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "ScapularRetraction", Description = "Scapular retraction" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "LegRaise", Description = "Leg raise" });
                col.Insert(new ListEntry { Type = "Legs6", Code = "BabyJumps", Description = "Baby jumps" });

                //BOOTY___________________________________________________________________________________________________
                col.Insert(new ListEntry { Type = "Booty1", Code = "PlieSquat", Description = "Plie squat" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "DonkeyKick", Description = "Donckey kick" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "GluteBridge", Description = "Glute bridge" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "JumpSquat", Description = "Jump squat" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "SingleLegLift", Description = "Single leg lift" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "DeadLift", Description = "Dead lift" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "HipThrusts", Description = "Hip thrust" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "Swimmers", Description = "Swimmers" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "SecondLunge", Description = "Second lunge" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "JumpSquat", Description = "Jumps squat" });

                col.Insert(new ListEntry { Type = "Booty2", Code = "KneeDrop", Description = "Knee drop" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "PlankDip", Description = "Plank dip" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "RussianTwist", Description = "Russian twist" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "ObliqueCrunch", Description = "Oblique crunch" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "JumpSquat", Description = "Jump squat" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "GluteBridge", Description = "Glute bridge" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "ScissorJump", Description = "Scissors jump" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "FlutterKick", Description = "Flutter kick" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "InnerThightLifts", Description = "Inner thight lifts" });
                col.Insert(new ListEntry { Type = "Booty2", Code = "ThightKillers", Description = "Thight killers" });

                col.Insert(new ListEntry { Type = "Booty3", Code = "SingleLegGlut", Description = "Single leg glut" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "Squat", Description = "Squat" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "DonkeyKick", Description = "Doncket kick" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "DiamondLegLift", Description = "Diamond leg lift" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "LegPulse", Description = "Leg pulse" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "CrossOverPulse", Description = "Cross over pulse" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "FireHydrate", Description = "Fire hydrate" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "JumpSquat", Description = "Jump squat" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "FrogJump", Description = "Frog jump" });
                col.Insert(new ListEntry { Type = "Booty3", Code = "MontainClimbers", Description = "Montain climbers" });

                col.Insert(new ListEntry { Type = "Booty4", Code = "DonkeyKick", Description = "Donckey kick" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "SquatCoreTwist", Description = "Squat core twist" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "JumpSquatPulse", Description = "Jumps squat pulse" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "SquatWalk", Description = "Squat walk" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "SquatHold", Description = "Squat hold" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "StraightKick", Description = "Straight kick" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "LegHoldLeft", Description = "Leg hold left" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "LegHoldRight", Description = "Leg hold right" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "WideSideSquats", Description = "Wide side squats" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "SquatHold", Description = "Squat hold" });

                col.Insert(new ListEntry { Type = "Booty5", Code = "KickBackRight", Description = "Kick back right" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "KickBackLeft", Description = "Kick back left" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "StraightSideLeft", Description = "Straight side left" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "StraightSideRight", Description = "Straight side right" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "SideLeftPulse", Description = "Side left pulse" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "SideRightPulse", Description = "Side right pulse" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "DonkeyKicks", Description = "Donkey kicks" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "StraightLegPulse", Description = "Straight leg pulse?" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "StraightLeftHold", Description = "Straight left hold" });
                col.Insert(new ListEntry { Type = "Booty5", Code = "StraightRigthHold", Description = "Straight right hold" });

                col.Insert(new ListEntry { Type = "Booty6", Code = "Burpees", Description = "Burpees" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "StanceSquats", Description = "Stance squats" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "DiagonalLeftRaise", Description = "Diagonal left raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "DiagonalRightRaise", Description = "Diagonal right raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "LateralLungeLegRaise", Description = "Lateral lunge leg raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "CrustyLungePulse", Description = "Crusty lunge pulse" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "SquatSideLeftRaise", Description = "Squats side left raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "SquatSideRightRaise", Description = "Squats side right raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "StandingRaise", Description = "Standing raise" });
                col.Insert(new ListEntry { Type = "Booty6", Code = "DonkeyKick", Description = "Donkey kick" });

                //FULLBODY_________________________________________________________________________________________________________________
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body1", Code = "", Description = "" });

                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body2", Code = "", Description = "" });

                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body3", Code = "", Description = "" });

                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body4", Code = "", Description = "" });

                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body5", Code = "", Description = "" });

                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
                col.Insert(new ListEntry { Type = "Body6", Code = "", Description = "" });
            
        }
    }
}
