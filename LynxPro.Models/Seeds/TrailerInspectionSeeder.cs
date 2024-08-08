namespace LynxPro.Models.Seeds
{
    public class TrailerInspectionSeeder
    {
        public static void Seed(LynxContext context, bool removeData = false)
        {
            if (removeData)
            {
                var defects = context.TrailerInspectionDefects;
                foreach (var defect in defects)
                {
                    context.TrailerInspectionDefects.Remove(defect);
                }

                var categories = context.TrailerInspectionCategories;
                foreach (var category in categories)
                {
                    context.TrailerInspectionCategories.Remove(category);
                }
            }

            context.TrailerInspectionCategories.Add(new TrailerInspectionCategory()
            {
                Description = "[[[[Brakes and Air System]]]]",
                TrailerInspectionDefects = new List<TrailerInspectionDefect>()
                {
                    new TrailerInspectionDefect() {Description="[[[[Scraping Noise]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Squeals]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Chatter]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Brake Fluid]]]]" },
                },
            });

            context.TrailerInspectionCategories.Add(new TrailerInspectionCategory()
            {
                Description = "[[[[Tyres, Wheels, and Rims]]]]",
                TrailerInspectionDefects = new List<TrailerInspectionDefect>()
                {
                    new TrailerInspectionDefect() {Description="[[[[Underinflation]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Overinflation]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Misalignment]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Tyre and Wheel Runout]]]]" },
                    new TrailerInspectionDefect() {Description="[[[[Tyre Vibration]]]]" },
                },
            });

            context.SaveChanges();
        }
    }
}
