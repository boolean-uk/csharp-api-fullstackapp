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
                    var item = repository.GetById(id);
                    
                    if (item == null) return Results.NotFound();



                    Payload<Complaint> payload = new Payload<Complaint>()
                    {
                        data = item
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
                    Complaint newComplaint = new Complaint();
                    newComplaint.name = model.name;
                    newComplaint.phone = model.phone;
                    newComplaint.address=model.address;
                    newComplaint.email=model.email;
                    newComplaint.consent = model.consent;
                    newComplaint.complaint = model.complaint;
                    newComplaint.contact = model.contact;
                    newComplaint.createdAt = DateTime.UtcNow;
                    newComplaint.updatedAt = DateTime.UtcNow;
                    repository.Insert(newComplaint);
                    repository.Save();

                    Payload<Complaint> payload = new Payload<Complaint>()
                    {
                        data = newComplaint
                    };

                    return Results.Created($"https://localhost:7195/complaints/{newComplaint.id}", payload);
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
