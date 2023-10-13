using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class ComplaintsApi
    {
        public static void ConfigureComplaintsApi(this WebApplication app)
        {
            app.MapPost("/complaints", AddComplaint);
            app.MapGet("/complaints", GetComplaints);
            app.MapGet("/complaints/{id}", GetComplaint);

        }
        public static async Task<IResult> GetComplaints(IRepository<Complaint> repository)
        {
            try
            {
                return await Task.Run(() =>
                {


                    Payload<IEnumerable<Complaint>> payload = new Payload<IEnumerable<Complaint>>()
                    {
                        data = repository.GetAll().ToList()
                    };

                    return Results.Ok(payload);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
}
public static async Task<IResult> GetComplaint(int id, IRepository<Complaint> repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var entity = repository.GetById(id);
                    
                    if (entity == null) return Results.NotFound();



                    Payload<Complaint> payload = new Payload<Complaint>()
                    {
                        data = entity
                    };

                    return Results.Ok(payload);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        public static async Task<IResult> AddComplaint(ComplaintFormModel model, IRepository<Complaint> repository)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (model == null) return Results.NotFound();
                    Complaint entity = new Complaint();
                    entity.name = model.name;
                    entity.phone = model.phone;
                    entity.address=model.address;
                    entity.email=model.email;
                    entity.consent = model.consent;
                    entity.complaint = model.complaint;
                    entity.contact = model.contact;
                    entity.createdAt = DateTime.UtcNow;
                    entity.updatedAt = DateTime.UtcNow;
                    repository.Insert(entity);
                    repository.Save();

                    Payload<Complaint> payload = new Payload<Complaint>()
                    {
                        data = entity
                    };

                    return Results.Created($"https://localhost:7195/complaints/{entity.id}", payload);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
