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
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/JumpSquat.png", Description = "Jump squat"}); //
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/PushUps.png", Description = "Pushups"}); //
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/JumpingLunge.png", Description = "Jumping lunges"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/Punches.png", Description = "Punches"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/Plank.png", Description = "Plank"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/Lunge.png", Description = "Lunge"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/SideLunge.png", Description = "Side lunge"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/Squat.png", Description = "Squat"});//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/JumpSquat.png", Description = "Jump squat" });//
                col.Insert(new ListEntry { Type = "Abs1", Code = "Assets/PushUps.png", Description = "Pushups" });//


                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/CountHold.png", Description = "Count hold" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/Scissors.png", Description = "Scissors" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/CountHold.png", Description = "Count hold" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/LegRaise.png", Description = "Leg raise" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/RaisedCircle.png", Description = "Raised circle" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/JackKnives.png", Description = "Jack knives" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/RaisedSwing.png", Description = "Raised swing" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/CountHold.png", Description = "Count hold" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/Scissors.png", Description = "Scissors" });//
                col.Insert(new ListEntry { Type = "Abs2", Code = "Assets/CountHold.png", Description = "Count hold" });//

                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/CycleAbs.png", Description = "Cycle abs" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/ObliqueCrunch.png", Description = "Oblique crunch" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/GlutBridges.png", Description = "Glut bridges" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/SidePlank.png", Description = "Side plank" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/GlutBridges.png", Description = "Glut bridges" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/PlankTwist.png", Description = "Plank twist" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/SideCrunchKick.png", Description = "Side crunch kick" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/Crunches.png", Description = "Crunches" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/SidePlank.png", Description = "Side plank" });//
                col.Insert(new ListEntry { Type = "Abs3", Code = "Assets/Squat.png", Description = "Squat" });//


                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/BreakDancerReach.png", Description = "Break dancer reach" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/Plank.png", Description = "Elbow plank" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/MontainClimber.png", Description = "Moutain climber" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/UpDownPlank.png", Description = "Updown plank" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/ClutBridges.png", Description = "Clut bridges" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/KneesToChest.png", Description = "Knees to chest" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/SideJack.png", Description = "Side jack" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/RussianTwist.png", Description = "Russian twist" });//
              col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/BreakDancerReach.png", Description = "Break dancer reach" });//
                col.Insert(new ListEntry { Type = "Abs4", Code = "Assets/Plank.png", Description = "Elbow plank" });//


                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/CycleAbs.png", Description = "Cycle abs" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/Crunch.png", Description = "Crunch" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/Reverse.png", Description = "Reverse" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/Plank.png", Description = "Plank" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/RussianTwist.png", Description = "Russian twist" });//
            col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/CrossCrunch.png", Description = "Cross crunch" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/KneeCrunch.png", Description = "Knee crunch" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/LongArmCrunches.png", Description = "Long arm crunch" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/CrossLeg.png", Description = "Cross leg" });//
                col.Insert(new ListEntry { Type = "Abs5", Code = "Assets/OneArmToe.png", Description = "One arm toe" });//

                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/Crunch.png", Description = "Crunch" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/CrossCrunch.png", Description = "Cross crunch" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/LegUp.png", Description = "Leg up" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/RaisedSwing.png", Description = "Raised swing" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/MontainClimbers.png", Description = "Moutain climbers" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/Plank.png", Description = "Plank" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/ObliqueTwists.png", Description = "Oblique twists" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/RightCrunchs.png", Description = "Right crunchs" });//
                col.Insert(new ListEntry { Type = "Abs6", Code = "Assets/LeftCrunchs.png", Description = "Left crunchs" });//

                //ARMS__________________________________________________________________________________________________

                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/WallPushUps.png", Description = "Wall push ups" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/ArmSwing.png", Description = "Arm swing" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/ArmCircle.png", Description = "Arm circle" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/JumpingJacks.png", Description = "Jumping jacks" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/TricepsDips.png", Description = "Triceps dips" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/Punchs.png", Description = "Punchs" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/KneePushUps.png", Description = "Knee push ups" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Arms1", Code = "Assets/JumpingJacks.png", Description = "Jumping jacks" });//

                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/PushUps.png", Description = "Push ups" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/PlankTaps.png", Description = "¨Plank taps" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/TricepsDips.png", Description = "Triceps dips" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/OverHeadPull.png", Description = "Over head pull" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/HammerCurl.png", Description = "Hammer curl" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/ShoulderPresses.png", Description = "Shoulder presses" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/ReverseFly.png", Description = "Reverse fly" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/PushUps.png", Description = "Push ups" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/PlankTaps.png", Description = "Plank taps" });//
                col.Insert(new ListEntry { Type = "Arms2", Code = "Assets/TricepsDips.png", Description = "Triceps dips" });//


                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/ArmPlunge.png", Description = "Arm plunge" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/PushAndStrech.png", Description = "Push and strech" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/Scissors.png", Description = "Scissors" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/ArmRotating.png", Description = "Arm rotating" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/NamasteEx.png", Description = "Namaste exercice" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/PushAndPull.png", Description = "Push and pull" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/PushUps.png", Description = "Push ups" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/SidePlank.png", Description = "Side plank" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/BicepsCurls.png", Description = "Biceps curls" });//
                col.Insert(new ListEntry { Type = "Arms3", Code = "Assets/ArmCircle.png", Description = "Arm circle" });//


                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/ChairPushUps.png", Description = "Chair push ups" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/PushUps.png", Description = "Push ups" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/ClapHands.png", Description = "Hand clap" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/ReverseFly.png", Description = "Reverse fly" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/JumpingRope.png", Description = "Jumping rope" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/TricepsDips.png", Description = "Triceps dips" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/DumbelSideRaise.png", Description = "Dumbel side raise" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/SidePlank.png", Description = "Side plank" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/ReverseFly.png", Description = "Revers fly" });//
                col.Insert(new ListEntry { Type = "Arms4", Code = "Assets/JumpingRope.png", Description = "Jumping rope" });//

                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/BarbelCurl.png", Description = "Barbel curl" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/ConcentrationCurl.png", Description = "Concentration curl" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/HammerCurl.png", Description = "Hammer curl" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/ReverseCurl.png", Description = "Reverse curl" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/DipsCurl.png", Description = "Dips curl" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/SkullCrusher.png", Description = "Skull crusher" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/CrushDown.png", Description = "Crush down" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/PushUps.png", Description = "Push ups" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/PushUpsClap.png", Description = "Clap push ups" });//
                col.Insert(new ListEntry { Type = "Arms5", Code = "Assets/PushDowns.png", Description = "Push down" });//

                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/TricepsDips.png", Description = "Dips" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/PushDown.png", Description = "Push down" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/Extensions.png", Description = "Extensions" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/DumbellExtensions.png", Description = "Dumbell extensions" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/SeatedBarbell.png", Description = "Seated barbell" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/OverheadBarbell.png", Description = "Overhead barbell" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/DumbelExtension.png", Description = "Seated extension" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/ArmRotating.png", Description = "Arms circle" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/ExtendedClench.png", Description = "Extended clench" });//
                col.Insert(new ListEntry { Type = "Arms6", Code = "Assets/SideExtendedClench.png", Description = "Side extended clench" });//

                //LEGS__________________________________________________________________________________________________

                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/TableTop.png", Description = "Table top" });//
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/GlutBridge.png", Description = "Glut bridge" });//
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/PilateCrunch.png", Description = "Pilate crunch" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/Dart.png", Description = "Dart" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/Plank.png", Description = "Plank" });//
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/JumpingJacks.png", Description = "Jumping jack" });//
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/AirPlanning.png", Description = "Superman" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/AlternateHeel.png", Description = "Alternate heel" });
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/Crunchs.png", Description = "Crunchs" });//
                col.Insert(new ListEntry { Type = "Legs1", Code = "Assets/MontainClimber.png", Description = "Montain climber" });//

                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/SumoSquat.png", Description = "Sumo squat" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/SideLegRaise.png", Description = "Side leg raise" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/DeepSideLunge.png", Description = "Deep side lunge" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/LegExtension.png", Description = "Leg extension" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/SideLegExtension.png", Description = "Side leg extension" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/SideLegRaise.png", Description = "Side leg raise" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/DonkeyKicks.png", Description = "Crossover extention" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/LyingLeftLift.png", Description = "Lying lift" });//
                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/Lunge.png", Description = "Lunge" });//

                col.Insert(new ListEntry { Type = "Legs2", Code = "Assets/ClutterBridge.png", Description = "Hip raise" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/FrogJump.png", Description = "Frog jump" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/SidePlank.png", Description = "Side plank" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/BulgarianSplit.png", Description = "Bulgarian split" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/BentOver.png", Description = "Bent over" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/SumoSquat.png", Description = "Sumo squat" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/OneLeggedRow.png", Description = "One legged row" });
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/PlieSquat.png", Description = "Plie squat" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/BentGlut.png", Description = "Bent glut" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/WallSit.png", Description = "Wall squat" });//
                col.Insert(new ListEntry { Type = "Legs3", Code = "Assets/SideLunge.png", Description = "Latteral lunge" });//


                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/LungeKick.png", Description = "Lunge kick" });
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/ClutterBridge.png", Description = "CLutter bridge" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/CycleAbs.png", Description = "Criss cross" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/BootyPush.png", Description = "Booty push" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/GobletSquat.png", Description = "Goblet squat" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/Squat.png", Description = "Squat" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/JumpSquat.png", Description = "Jump squat" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/SideLunge.png", Description = "Side lunge" });//
                col.Insert(new ListEntry { Type = "Legs4", Code = "Assets/ClutterBridge.png", Description = "Clutter bridge" });//

                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/Squat.png", Description = "Squat" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/Lunge.png", Description = "Lunge" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/SideLunge.png", Description = "Side lunge" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/CalfRaise.png", Description = "Calf raise" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/LegStraight.png", Description = "Leg straight raise" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/PullOver.png", Description = "Pull over" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/BigCurl.png", Description = "Big curl" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/JumpSquat.png", Description = "Squat jumps" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/Swing.png", Description = "Swing" });//
                col.Insert(new ListEntry { Type = "Legs5", Code = "Assets/SplitLunges.png", Description = "Split lunges" });//

                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/StandingLegAbduction.png", Description = "Standing leg abduction" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/StandingHipExtension.png", Description = "Standing hip extension" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/Lunge.png", Description = "Lunge" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/StandingCurls.png", Description = "Standing curls" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/OverheadPush.png", Description = "Overhead push" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/LyingLegAbduction.png", Description = "Lying leg abduction" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/LegCurlProne.png", Description = "Leg curl prone" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/Swing.png", Description = "Swing" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/LegRaise.png", Description = "Leg raise" });//
                col.Insert(new ListEntry { Type = "Legs6", Code = "Assets/BabyJumps.png", Description = "Baby jumps" });//

                //BOOTY___________________________________________________________________________________________________
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/PlieSquat.png", Description = "Plie squat" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/DonkeyKick.png", Description = "Donckey kick" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/GluteBridge.png", Description = "Glute bridge" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/JumpSquat.png", Description = "Jump squat" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/SingleLegGlut.png", Description = "Single leg lift" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/DeadLift.png", Description = "Dead lift" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/ClutterBridge.png", Description = "Clutter bridge" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/Swimmers.png", Description = "Swimmers" });//
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/SecondLunge.png", Description = "Second lunge" });
                col.Insert(new ListEntry { Type = "Booty1", Code = "Assets/JumpSquat.png", Description = "Jumps squat" });//

                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/KneeDrop.png", Description = "Knee drop" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/PlankDip.png", Description = "Plank dip" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/RussianTwist.png", Description = "Russian twist" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/ObliqueCrunch.png", Description = "Oblique crunch" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/JumpSquat.png", Description = "Jump squat" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/GluteBridge.png", Description = "Glute bridge" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/ScissorJump.png", Description = "Scissors jump" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/FlutterKick.png", Description = "Flutter kick" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/InnerThightLifts.png", Description = "Inner thight lifts" });//
                col.Insert(new ListEntry { Type = "Booty2", Code = "Assets/CrossOverPulse.png", Description = "Cross over pulse" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/SingleLegGlut.png", Description = "Single leg glut" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/Squat.png", Description = "Squat" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/DonkeyKick.png", Description = "Donckey kick" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/DiamondLegLift.png", Description = "Diamond leg lift" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/LegPulse.png", Description = "Leg pulse" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/CrossOverPulse.png", Description = "Cross over pulse" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/FireHydrate.png", Description = "Fire hydrate" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/JumpSquat.png", Description = "Jump squat" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/FrogJump.png", Description = "Frog jump" });//
                col.Insert(new ListEntry { Type = "Booty3", Code = "Assets/MontainClimbers.png", Description = "Montain climbers" });//

                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/DonkeyKick.png", Description = "Donckey kick" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/SquatCoreTwist.png", Description = "Squat core twist" });
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/JumpSquat.png", Description = "Jumps squat pulse" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/SquatWalk.png", Description = "Squat walk" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/SquatHold.png", Description = "Squat hold" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/StraightKick.png", Description = "Straight kick" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/StraightLeftHold.png", Description = "Leg hold left" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/StraightRigthHold.png", Description = "Leg hold right" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/WideSideSquats.png", Description = "Wide side squats" });//
                col.Insert(new ListEntry { Type = "Booty4", Code = "Assets/SquatHold.png", Description = "Squat hold" });//

                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/DonkeyKick.png", Description = "Kick back right" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/DonkeyKick.png", Description = "Kick back left" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/StraightSideLeft.png", Description = "Straight side left" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/StraightSideRight.png", Description = "Straight side right" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/SideLeftPulse.png", Description = "Side left pulse lunges" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/SideRightPulse.png", Description = "Side right pulse lunges" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/DonkeyKicks.png", Description = "Donkey kicks" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/StraightLegPulse.png", Description = "Straight leg pulse" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/StraightLeftHold.png", Description = "Straight left hold" });//
                col.Insert(new ListEntry { Type = "Booty5", Code = "Assets/StraightRigthHold.png", Description = "Straight right hold" });//


                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/Squats.png", Description = "Squats" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/DiagonalLeftRaise.png", Description = "Diagonal left raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/DiagonalRightRaise.png", Description = "Diagonal right raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/LateralLungeLegRaise.png", Description = "Lateral lunge leg raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/CrustyLungePulse.png", Description = "Crusty lunge pulse" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/SquatSideLeftRaise.png", Description = "Squats side left raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/SquatSideRightRaise.png", Description = "Squats side right raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/StandingRaise.png", Description = "Standing raise" });//
                col.Insert(new ListEntry { Type = "Booty6", Code = "Assets/DonkeyKicks.png", Description = "Donkey kick" });//

                //FULLBODY_________________________________________________________________________________________________________________
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/Squat.png", Description = "Squat" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/ReverseLunge.png", Description = "Reverse Lunge" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/KneePushUps.png", Description = "Kneeling Pushup" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/WideRows.png", Description = "Wide Rows" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/ReachingPushup.png", Description = "Reaching Pushup" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/NarrowRows.png", Description = "Narrow Rows" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/SideLunge.png", Description = "Side Lunge" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/BicycleCrunch.png", Description = "Bicycle Crunch" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/SpiderPushup.png", Description = "Spider Pushup" });//
                col.Insert(new ListEntry { Type = "Body1", Code = "Assets/DiagonalLunge.png", Description = "Diagonal Lunge" });

                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/JumpingJacks.png", Description = "Jumping Jacks" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/WallSit.png", Description = "Wall Sit" });
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/PushUp.png", Description = "Push-ups" });////
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/Crunches.png", Description = "Crunches" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/ChairStepUps.png", Description = "Chair Step-ups" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/Squats.png", Description = "Squats" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/TricepsDips.png", Description = "Triceps Dips" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/Plank.png", Description = "Plank" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/Lunges.png", Description = "Lunges" });//
                col.Insert(new ListEntry { Type = "Body2", Code = "Assets/PushUpRotations.png", Description = "Push-up rotations" });//

                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/JumpingJacks.png", Description = "Jumping Jacks" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/MountainClimbers.png", Description = "Mountain Climbers" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/Burpees.png", Description = "Burpees" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/HighKnees.png", Description = "High Knees" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/TricepsDips.png", Description = "Tricep dips" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/Squats.png", Description = "Squats" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/DonkeyKicks.png", Description = "Donkey Kicks" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/Crunches.png", Description = "Crunches" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/BicycleCrunch.png", Description = "Bicycle Crunch" });//
                col.Insert(new ListEntry { Type = "Body3", Code = "Assets/In&Out.png", Description = "In&Outs" });//

                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/MarchSteps.png", Description = "March Steps" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/HighKnees.png", Description = "High knees" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/ArmCircle.png", Description = "Arm Circles" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/BicepExtensions.png", Description = "Bicep Extensions" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/Squat.png", Description = "Squat" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/JumpingJacks.png", Description = "Jumping Jacks" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/MountainClimbers.png", Description = "Mountain Climbers" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/HighKnees.png", Description = "High knees" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/BicepExtensions.png", Description = "Bicep Extensions" });//
                col.Insert(new ListEntry { Type = "Body4", Code = "Assets/Squat.png", Description = "Squat" });//

                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/SingleLegSquatLeft.png", Description = "Single Leg Squat Left" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/SingleLegSquatRight.png", Description = "Single Leg Squat Right" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/CrossackSquatsRight.png", Description = "Crossack Squats Right" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/CrossackSquatsLeft.png", Description = "Crossack Squats Left" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/DeclinePushUps.png", Description = "Decline Push Ups" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/Punches.png", Description = "Punches" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/UpDownPlank.png", Description = "Up & down planks" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/ElbowPlank.png", Description = "Elbow plank side crunches" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/AbRows.png", Description = "Ab Rows" });//
                col.Insert(new ListEntry { Type = "Body5", Code = "Assets/SitUpsTwists.png", Description = "Sit Up Twists" });//

                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/SingleLegSquatLeft.png", Description = "Single Leg Squat Left" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/SingleLegSquatRight.png", Description = "Single Leg Squat Right" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/HighKnees.png", Description = "High knees" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/MountainClimbers.png", Description = "Mountain Climbers" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/SitUpsTwists.png", Description = "Sit Up Twists" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/ElbowPlank.png", Description = "Elbow plank side crunches" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/Bicycles.png", Description = "Bicycles" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/In&Out.png", Description = "In&Outs" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/KneePushUps.png", Description = "Kneeling Pushup" });//
                col.Insert(new ListEntry { Type = "Body6", Code = "Assets/Squat.png", Description = "Squat" });//
            
        }
    }
}
