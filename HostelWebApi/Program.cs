using Hostel.Domain.Doamin;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var hotels = new List<HotelModel>();
app.MapGet("/api/hotels", () => hotels);
app.MapGet("/api/hotels/{id}", (int id) => hotels.Where(h => h.Id == id));
app.MapPost("api/hotels", (HotelModel hotel) => hotels.Add(hotel));
app.MapPut("api/hotels", (HotelModel hotel) => {
    var index = hotels.FindIndex( h => h.Id == hotel.Id);
    if(index < 0)
    {
        throw new ArgumentNullException("hotel is not found");
    }
    hotels[index] = hotel;
});
app.MapDelete("api/hotels/{id}", (int id) => {
    var index = hotels.FindIndex(h => h.Id == id);
    if(index < 0)
    {
        throw new ArgumentNullException("hotel is not found");
    }
    hotels.RemoveAt(index);
});

app.Run();

