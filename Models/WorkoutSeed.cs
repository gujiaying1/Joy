using System.Collections.Generic;
using JoyRiseFitness.Models;

namespace JoyRiseFitness.Models
{
    public static class WorkoutSeed
    {
        public static List<Workout> Seed() => new List<Workout>
        {
            new Workout
            {
                Id = 1,
                Name = "Barbell Bench Press",
                Part  = MusclePart.Chest,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1661286749098-fd5d4678e320?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Adjust bench to flat, feet firmly on floor.",
                    "Press dumbbells up until arms are fully extended.",
                    "Lower slowly to chest level and repeat."
                },
                Alternatives = new List<string>{ "Barbell Bench Press", "Push-Ups" }
            },

            new Workout
            {
                Id = 2,
                Name = "Dumbbell Shoulder Press",
                Part  = MusclePart.Shoulders,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1664476845281-a29067796a2f?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Keep body in a straight line from head to heels.",
                    "Lower chest until it almost touches the floor.",
                    "Push back up to starting position."
                },
                Alternatives = new List<string>{ "Knee Push-Up", "Incline Push-Up" }
            },

            new Workout
            {
                Id = 3,
                Name = "Lat Pull-down",
                Part  = MusclePart.Back,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1672862926934-d9f7e3f33632?q=80&w=687&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Hang with arms fully extended, palms facing away.",
                    "Pull body up until chin clears the bar.",
                    "Lower with control to full extension."
                },
                Alternatives = new List<string>{ "Lat Pull-Down", "Assisted Pull-Up" }
            },

            new Workout
            {
                Id = 4,
                Name = "Leg Press",
                Part  = MusclePart.Legs,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1571019613723-c7e5b75bd4c6?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Set bar on upper traps, feet shoulder-width apart.",
                    "Descend until hips are below knee level.",
                    "Drive through heels to return to standing."
                },
                Alternatives = new List<string>{ "Goblet Squat", "Leg Press" }
            },

            new Workout
            {
                Id = 5,
                Name = "Biceps Curl",
                Part  = MusclePart.Arms,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1661265933107-85a5dbd815af?q=80&w=1118&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Hold dumbbells at sides with slight bend in elbows.",
                    "Raise weights out to sides until arms are parallel to floor.",
                    "Lower slowly under control."
                },
                Alternatives = new List<string>{ "Cable Lateral Raise", "Machine Lateral Raise" }
            },

            new Workout
            {
                Id = 6,
                Name = "Plank",
                Part  = MusclePart.Core,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1672352100050-65cb2ee4d818?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Stand tall, elbows close to torso.",
                    "Curl weights up while contracting biceps.",
                    "Lower slowly to starting position."
                },
                Alternatives = new List<string>{ "Barbell Curl", "Cable Curl" }
            },

            new Workout
            {
                Id = 7,
                Name = "Smith Machine Squat",
                Part  = MusclePart.Legs,
                Difficulty = "Intermediate",
                ImgUrl = "https://images.unsplash.com/photo-1653276527526-f902a569d3c9?q=80&w=764&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Lie face down, elbows under shoulders.",
                    "Lift body off ground, forming straight line.",
                    "Hold position while breathing normally."
                },
                Alternatives = new List<string>{ "Side Plank", "Reverse Plank" }
            },

            new Workout
            {
                Id = 8,
                Name = "Cable Wood-chop",
                Part  = MusclePart.Core,
                Difficulty = "Intermediate",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1663047570926-2fed4638b79a?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Sit with thighs secured, grip bar wider than shoulders.",
                    "Pull bar to upper chest, lean slightly back.",
                    "Return bar slowly with control."
                },
                Alternatives = new List<string>{ "Pull-Up", "Straight-arm Pull-down" }
            },

            new Workout
            {
                Id = 9,
                Name = "Hip Thrust",
                Part  = MusclePart.Legs,
                Difficulty = "Intermediate",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1661407412468-dc5059bb4098?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Z2x1dGUlMjBicmlkZ2V8ZW58MHx8MHx8fDA%3D",
                Steps = new List<string>
                {
                    "Place feet shoulder-width on platform.",
                    "Lower weight until knees are 90°.",
                    "Press through heels back to start."
                },
                Alternatives = new List<string>{ "Squat", "Bulgarian Split Squat" }
            },

            new Workout
            {
                Id = 10,
                Name = "Pec Deck Fly",
                Part  = MusclePart.Chest,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1663076314882-d16c23ffe2e8?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjh8fCVFNSU4MSVBNSVFOCVCQSVBQnxlbnwwfHwwfHx8MA%3D%3D",
                Steps = new List<string>
                {
                    "Stand upright, elbows tucked to sides.",
                    "Push cable bar down until arms fully extended.",
                    "Return slowly without moving upper arms."
                },
                Alternatives = new List<string>{ "Overhead Extension", "Close-grip Push-up" }
            },

            new Workout
            {
                Id = 11,
                Name = "Seated Row",
                Part  = MusclePart.Back,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1664299683145-d5ae24790f8e?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Steps = new List<string>
                {
                    "Rest upper back on bench, barbell over hips.",
                    "Drive hips up until body forms straight line.",
                    "Lower under control, repeat."
                },
                Alternatives = new List<string>{ "Glute Bridge", "Romanian Deadlift" }
            },

            new Workout
            {
                Id = 12,
                Name = "Triceps Push-down",
                Part  = MusclePart.Arms,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/flagged/photo-1597786776169-17549989c2bf?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8VHJpY2VwcyUyMFB1c2gtZG93bnxlbnwwfHwwfHx8MA%3D%3D",
                Steps = new List<string>
                {
                    "Sit upright, knees slightly bent, feet on platform.",
                    "Pull handle to lower chest, squeeze shoulder blades.",
                    "Return slowly with control."
                },
                Alternatives = new List<string>{ "Barbell Row", "Dumbbell Row" }
            }
        };
    }
}