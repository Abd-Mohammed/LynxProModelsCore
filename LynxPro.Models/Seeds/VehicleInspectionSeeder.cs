namespace LynxPro.Models.Seeds
{
    public class VehicleInspectionSeeder
    {
        public static void Seed(LynxContext context, bool removeData = false)
        {
            if (removeData)
            {
                var defects = context.VehicleInspectionDefects;
                foreach (var defect in defects)
                {
                    context.VehicleInspectionDefects.Remove(defect);
                }

                var categories = context.VehicleInspectionCategories;
                foreach (var category in categories)
                {
                    context.VehicleInspectionCategories.Remove(category);
                }
            }

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Brakes and Air System]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Low Brake Fluid]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Low Brake Pedal]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Spongy or Soft Pedal]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Scraping Noise]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Squeals]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Chatter]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Grabby Brakes]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Dragging Brakes]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Hard Pedal]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Brake Fluid]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Brakes Pull to One Side]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Steering Mechanism]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Vibration, Shimmy or Shake Steering]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Stiff Electric Steering]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Stiff Steering on One Side Only]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Stiff Hydraulic Steering]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Hydraulic Leaks]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Steering Wheel Off Center]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Steering That Pulls or Drifts]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Squeals]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Lights and Reflectors]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Headlights]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Headlamps]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Headlamp Switch]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Circuit Breaker]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Ignition Switch]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Taillights and Brake Lights]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Tyres, Wheels, and Rims]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Underinflation]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Overinflation]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Misalignment]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Tyre and Wheel Runout]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Tyre Vibration]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Windshield Wipers]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Worn Blades]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Sub-par Windshield Wiper Fluid]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Old or Hard Blades]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Chattering]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Washer Fluid Tank and Tubes Leaks]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Clogged Spray Nozzles]]]]" }
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Rear View Mirrors]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Sensors Off]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Discoloration]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[No Rearview Mirror]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Auto Dimming Does Not Work]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Coupling Equipment and Fifth Wheels]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Front Suspension Loading]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Jack-Knifing Damage]]]]" },
                },
            });

            context.VehicleInspectionCategories.Add(new VehicleInspectionCategory()
            {
                Description = "[[[[Safety and Emergency equipment]]]]",
                VehicleInspectionDefects = new List<VehicleInspectionDefect>()
                {
                    new VehicleInspectionDefect() {Description="[[[[Missing Air Bags]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Compromised Bumpers]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Dying or Damaged Batteries]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Damaged Drive Belts]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Missing Fire Extinguisher]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[Missing First-aid Kit]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[No Spare Tyres]]]]" },
                    new VehicleInspectionDefect() {Description="[[[[No Extra Windshield Fluid]]]]" },
                },
            });


            context.SaveChanges();
        }
    }
}
