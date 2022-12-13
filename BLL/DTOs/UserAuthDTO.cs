namespace BLL.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? UsbDeviceId { get; set; }
        public Guid DeviceId { get; set; }
    }
}

