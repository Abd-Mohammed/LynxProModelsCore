namespace LynxPro.Models.Seeds
{
    public class HosStatusSeeder
    {
        public static void Seed(LynxContext context)
        {
            context.HosStatuses.Add(new HosStatus() { Acronym = "ON", Description = "On Duty" });
            context.HosStatuses.Add(new HosStatus() { Acronym = "D", Description = "Driving" });
            context.HosStatuses.Add(new HosStatus() { Acronym = "OFF", Description = "Off Duty" });
            context.HosStatuses.Add(new HosStatus() { Acronym = "SB", Description = "Sleeper Berth" });
            context.HosStatuses.Add(new HosStatus() { Acronym = "PC", Description = "Personal Conveyance" });
            context.SaveChanges();
        }
    }
}
