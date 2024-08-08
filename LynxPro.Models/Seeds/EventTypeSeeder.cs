namespace LynxPro.Models.Seeds
{
    public class EventTypeSeeder
    {
        public static void Seed(LynxContext context)
        {
            context.EventTypes.Add(new EventType() { Name = "Swipe In", Code = "SWPIN" });
            context.EventTypes.Add(new EventType() { Name = "Swipe Out", Code = "SWPOUT" });
            context.EventTypes.Add(new EventType() { Name = "Emergency", Code = "EMERG" });
            context.EventTypes.Add(new EventType() { Name = "Breakdown", Code = "BD" });
            context.EventTypes.Add(new EventType() { Name = "Swipe", Code = "SWP" });
            context.EventTypes.Add(new EventType() { Name = "Start Route", Code = "STARTRTE" });
            context.EventTypes.Add(new EventType() { Name = "End Route", Code = "ENDRTE" });
            context.EventTypes.Add(new EventType() { Name = "Complete Service", Code = "COMSVC" });
            context.EventTypes.Add(new EventType() { Name = "Break In", Code = "BRKIN" });
            context.EventTypes.Add(new EventType() { Name = "Break Out", Code = "BRKOUT" });
            context.EventTypes.Add(new EventType() { Name = "End Job", Code = "ENDJOB" });
            context.EventTypes.Add(new EventType() { Name = "Start Job", Code = "STARTJOB" });
            context.EventTypes.Add(new EventType() { Name = "Success Pickup", Code = "SUCCPU" });
            context.EventTypes.Add(new EventType() { Name = "Failed Pickup", Code = "FAILPU" });
            context.EventTypes.Add(new EventType() { Name = "Success Deliver", Code = "SUCCDLVR" });
            context.EventTypes.Add(new EventType() { Name = "Failed Deliver", Code = "FAILDLVR" });
            context.EventTypes.Add(new EventType() { Name = "BLE Disconnect", Code = "BLEDISC" });
            context.EventTypes.Add(new EventType() { Name = "Customer Emergency", Code = "CUSEMERG" });
            context.SaveChanges();
        }
    }
}