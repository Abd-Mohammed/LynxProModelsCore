namespace LynxPro.Models.Seeds
{
    public class AlarmTypeSeeder
    {
        public static void Seed(LynxContext context)
        {
            context.AlarmTypes.Add(new AlarmType() { Name = "Video Loss", Code = 0 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Video Cover", Code = 1 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Speed", Code = 8 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Low Voltage", Code = 9 });
            context.AlarmTypes.Add(new AlarmType() { Name = "G-Sensor", Code = 18 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Illegal Shutdown", Code = 38 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Fatigue", Code = 64 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Lost and Found", Code = 66 });
            // ME exclusive            
            context.AlarmTypes.Add(new AlarmType() { Name = "Illegal ACC", Code = 95 });
            context.AlarmTypes.Add(new AlarmType() { Name = "AI Driver Distraction", Code = 100 });
            context.AlarmTypes.Add(new AlarmType() { Name = "AI Illegal Passenger", Code = 101 });
            context.AlarmTypes.Add(new AlarmType() { Name = "AI Video Loss", Code = 102 });
            context.AlarmTypes.Add(new AlarmType() { Name = "AI Camera Tampering", Code = 103 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Fatigue 2.0", Code = 200 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Yawning", Code = 201 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Smoking", Code = 202 });
            context.AlarmTypes.Add(new AlarmType() { Name = "Phoning", Code = 203 });

            context.SaveChanges();
        }
    }
}
