using RimWorld;

namespace AdvancedNutritionHealth
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

    public class StatPart_Protein : StatPart
    {
        public static float DAILY_NUTRITION = 1.6f;

        // Called when the Protein value is being set up
        public override void TransformValue(StatRequest request, ref float protein)
        {
            // Set up the plants protein
            if (request.HasThing && request.Thing.def.IsPlant)
            {
                float nutrition = request.Thing.GetStatValue(StatDefOf.Nutrition, true);

                protein += (nutrition / DAILY_NUTRITION) * (float)Protein.Medium;
            }
        }

        public override string ExplanationPart(StatRequest request)
        {
            return null;
        }
    }

    public class StatPart_Carbohydrate : StatPart
    {
        public static float DAILY_NUTRITION = 1.6f;

        // Called when the Carbohydrate value is being set up
        public override void TransformValue(StatRequest request, ref float carbohydrate)
        {
            // Set up the plants carbohydrate
            if (request.HasThing && request.Thing.def.IsPlant)
            {
                float nutrition = request.Thing.GetStatValue(StatDefOf.Nutrition, true);

                carbohydrate += (nutrition / DAILY_NUTRITION) * (float)Carbohydrate.High;
            }
        }

        public override string ExplanationPart(StatRequest request)
        {
            return null;
        }
    }

    public class StatPart_Fat : StatPart
    {
        public static float DAILY_NUTRITION = 1.6f;

        // Called when the Carbohydrate value is being set up
        public override void TransformValue(StatRequest request, ref float fat)
        {
            // Set up the plants carbohydrate
            if (request.HasThing && request.Thing.def.IsPlant)
            {
                float nutrition = request.Thing.GetStatValue(StatDefOf.Nutrition, true);

                fat += (nutrition / DAILY_NUTRITION) * (float)Fat.Low;
            }
        }

        public override string ExplanationPart(StatRequest request)
        {
            return null;
        }
    }
}
