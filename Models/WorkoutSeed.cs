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
                Name = "Dumbbell Bench Press",
                Part = MusclePart.Chest,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1581009137042-c552e485697a?w=640",
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
                Name = "Push-Up",
                Part = MusclePart.Chest,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1599058945522-28d584b6f0ff?w=640",
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
                Name = "Pull-Up",
                Part = MusclePart.Back,
                Difficulty = "Intermediate",
                ImgUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=640",
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
                Name = "Barbell Squat",
                Part = MusclePart.Legs,
                Difficulty = "Intermediate",
                ImgUrl = "https://images.unsplash.com/photo-1541534741688-6078c6bfb5c5?w=640",
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
                Name = "Dumbbell Lateral Raise",
                Part = MusclePart.Shoulders,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1584464491033-06628f3a6b7b?w=640",
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
                Name = "Dumbbell Biceps Curl",
                Part = MusclePart.Arms,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a?w=640",
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
                Name = "Plank",
                Part = MusclePart.Core,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1518310383802-640c2de311b2?w=640",
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
                Name = "Lat Pull-down",
                Part = MusclePart.Back,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1549476464-373922113543?w=640",
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
                Name = "Leg Press",
                Part = MusclePart.Legs,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1558611848-73f7eb4001a1?w=640",
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
                Name = "Cable Triceps Push-down",
                Part = MusclePart.Arms,
                Difficulty = "Beginner",
                ImgUrl = "https://images.unsplash.com/photo-1530822847156-5df684ec5ee1?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
                Name = "Hip Thrust",
                Part = MusclePart.Legs,
                Difficulty = "Intermediate",
                ImgUrl = "https://images.unsplash.com/photo-1599058945522-28d584b6f0ff?w=640",
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
                Name = "Seated Cable Row",
                Part = MusclePart.Back,
                Difficulty = "Beginner",
                ImgUrl = "https://plus.unsplash.com/premium_photo-1661962287338-a228bb258cb2?q=80&w=1171&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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