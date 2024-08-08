using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public enum VisionBehaviorType
    {
        Phone = 1,
        Sleep = 2,
        Smoke = 3,
        Yawn = 4,
        Smile = 5,
        EatDrink = 6,
        Text = 7,
        HandsOff = 8,
        EyesOff = 9,
        Yaw = 10,
        MaskOff = 11,
        HeadUncover = 12
    }

    public enum VisionEmotionType
    {
        Happy = 1,
        Sad = 2,
        Angry = 3,
        Confused = 4,
        Disgusted = 5,
        Surprised = 6,
        Calm = 7,
        Fear = 8,
        Unknown = 9
    }

    public enum VisionCameraDisturbanceType
    {
        Tamper = 1,
        Unplug = 2
    }

    public class Vision
    {
        [JsonProperty("blob", Required = Required.DisallowNull)]
        public VisionBlob Blob { get; set; }

        [JsonProperty("detection", Required = Required.DisallowNull)]
        public VisionDetection Detection { get; set; }

        [JsonProperty("behaviors", Required = Required.DisallowNull)]
        public IEnumerable<VisionBehavior> Behaviors { get; set; }

        [JsonProperty("faces", Required = Required.DisallowNull)]
        public IEnumerable<VisionFace> Faces { get; set; }

        [JsonProperty("objects", Required = Required.DisallowNull)]
        public IEnumerable<VisionObject> Objects { get; set; }

        [JsonProperty("timestamp", Required = Required.DisallowNull)]
        public DateTime? Timestamp { get; set; }
    }

    public class VisionBlob
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }

    public class VisionDetection
    {
        [JsonProperty("peopleCount", Required = Required.DisallowNull)]
        public int? PeopleCount { get; set; }

        [JsonProperty("cameraDisturbances", Required = Required.DisallowNull)]
        public IEnumerable<VisionCameraDisturbance> CameraDisturbances { get; set; }

        [JsonProperty("text", Required = Required.DisallowNull)]
        public string Text { get; set; }

        [JsonProperty("timestamp", Required = Required.DisallowNull)]
        public DateTime? Timestamp { get; set; }
    }

    public class VisionCameraDisturbance
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public VisionCameraDisturbanceType Type { get; set; }

        [JsonProperty("cams", Required = Required.DisallowNull)]
        public IEnumerable<int> Cams { get; set; }
    }

    public class VisionRectangle
    {
        [JsonProperty("x", Required = Required.Always)]
        public int PositionX { get; set; }

        [JsonProperty("y", Required = Required.Always)]
        public int PositionY { get; set; }

        [JsonProperty("w", Required = Required.Always)]
        public int Width { get; set; }

        [JsonProperty("h", Required = Required.Always)]
        public int Height { get; set; }
    }

    public class VisionBehavior
    {
        [JsonProperty("rectangle", Required = Required.DisallowNull)]
        public VisionRectangle Rectangle { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("behavior", Required = Required.Always)]
        public VisionBehaviorType Behavior { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull)]
        public string Description { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }

    public class VisionObject
    {
        [JsonProperty("rectangle", Required = Required.DisallowNull)]
        public VisionRectangle Rectangle { get; set; }

        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull)]
        public string Description { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }
    }

    public class VisionFace
    {
        [JsonProperty("rectangle", Required = Required.DisallowNull)]
        public VisionRectangle Rectangle { get; set; }

        [JsonProperty("confidence", Required = Required.DisallowNull)]
        public double? Confidence { get; set; }

        [JsonProperty("emotions", Required = Required.Always)]
        public IEnumerable<VisionEmotion> Emotions { get; set; }
    }

    public class VisionEmotion
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("emotion", Required = Required.Always)]
        public VisionEmotionType Emotion { get; set; }
    }
}