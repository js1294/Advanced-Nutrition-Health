using RimWorld;
using Verse;

namespace SetNutrition
{
    enum Protein
    {
        High = 120,
        Medium = 60,
        Low = 30
    }

    enum Carbohydrate
    {
        High = 300,
        Medium = 150,
        Low = 75
    }

    enum Fat
    {
        High = 60,
        Medium = 30,
        Low = 15
    }

    public class SetNutrition
    {
        public static float DAILY_NUTRITION = 1.6f;

        public class StatPart_Protein : StatPart
        {
            /// <summary>
            /// Set the protein value for the thing.
            /// </summary>
            /// <param name="request">The stat request to set the fat value to.</param>
            /// <param name="protein">The protein value on the thing to be set.</param>
            public override void TransformValue(StatRequest request, ref float protein)
            {
                // Cannot set protein if it is not a thing
                if (!request.HasThing)
                    return;

                // Calculate and set the plant thing's protein
                if (request.Thing.def.IsPlant)
                {
                    protein = CalculateNutrition(request.Thing, (float)Carbohydrate.Low);
                    return;
                }

                // Calculate and set the meat thing's protein
                if (request.Thing.def.IsMeat)
                {
                    protein = CalculateNutrition(request.Thing, (float)Carbohydrate.High);
                    return;
                }
            }

            /// <summary>
            /// Abstract class so needs to be overridden.
            /// Nothing is done.
            /// </summary>
            /// <param name="request">The request</param>
            /// <returns>Returns null</returns>
            public override string ExplanationPart(StatRequest request)
            {
                return null;
            }
        }

        public class StatPart_Carbohydrate : StatPart
        {
            /// <summary>
            /// Set the carbohydrate value for the thing.
            /// </summary>
            /// <param name="request">The stat request to set the fat value to.</param>
            /// <param name="carbohydrate">The carbohydrate value on the thing to be set.</param>
            public override void TransformValue(StatRequest request, ref float carbohydrate)
            {
                // Cannot set carbohydrate if it is not a thing
                if (!request.HasThing)
                    return;

                // Calculate and set the plant thing's carbohydrate
                if (request.Thing.def.IsPlant)
                {
                    carbohydrate = CalculateNutrition(request.Thing, (float)Carbohydrate.High);
                    return;
                }

                // Calculate and set the meat thing's carbohydrate
                if (request.Thing.def.IsMeat)
                {
                    carbohydrate = CalculateNutrition(request.Thing, (float)Carbohydrate.Low);
                    return;
                }
            }

            /// <summary>
            /// Abstract class so needs to be overridden.
            /// Nothing is done.
            /// </summary>
            /// <param name="request">The request</param>
            /// <returns>Returns null</returns>
            public override string ExplanationPart(StatRequest request)
            {
                return null;
            }
        }

        public class StatPart_Fat : StatPart
        {
            /// <summary>
            /// Set the fat value for the thing.
            /// </summary>
            /// <param name="request">The stat request to set the fat value to.</param>
            /// <param name="fat">The fat value on the thing to be set.</param>
            public override void TransformValue(StatRequest request, ref float fat)
            {
                // Cannot set fat if it is not a thing
                if (!request.HasThing)
                    return;

                // Calculate and set the plant thing's Fat
                if (request.Thing.def.IsPlant)
                {
                    fat = CalculateNutrition(request.Thing, (float)Fat.Low);
                    return;
                }

                // Calculate and set the meat thing's Fat
                if (request.Thing.def.IsMeat)
                {
                    fat = CalculateNutrition(request.Thing, (float)Fat.Medium);
                    return;
                }
            }

            /// <summary>
            /// Abstract class so needs to be overridden.
            /// Nothing is done.
            /// </summary>
            /// <param name="request">The request</param>
            /// <returns>Returns null</returns>
            public override string ExplanationPart(StatRequest request)
            {
                return null;
            }
        }

        /// <summary>
        /// Calculates the nutrition (e.g. carbohydrate, protein) for the thing (e.g. meat, plant).
        /// Finds the amount of nutrition this thing represents out of a pawns daily nutrition, times it by the nutrition level provided and adds some randomness (plus or minus 0.5).
        /// </summary>
        /// <param name="thing">The thing to calculate the macro nutrient value for.</param>
        /// <param name="nutritionLevel">The nutrient level expected (e.g. meat has high protein, plants have high carbohydrates)</param>
        /// <returns>The calculated macro nutrient value</returns>
        public static float CalculateNutrition(Thing thing, float nutritionLevel)
        {
            // Generate randomness with seed based on the thing's hash code.
            // Just to add randomness that should not change.
            int hash = thing.def.defName.GetHashCode();
            System.Random random = new System.Random(hash);

            float nutrition = thing.GetStatValue(StatDefOf.Nutrition, true);

            return ((nutrition / DAILY_NUTRITION) * nutritionLevel) + (0.5f - (float)random.NextDouble());
        }

    }
}
