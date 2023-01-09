using Dapper;
using Microsoft.Graph;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Repository
{
    public class SegmentMasterRepository : ISegmentMasterRepository
    {
        private readonly DapperContext _context;
        public SegmentMasterRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<List<SegmentMasterModel>> GetAll()
        {
            List<SegmentMasterModel> segmentMasterModels = new List<SegmentMasterModel>();
            var query = "select * from tblsegmentmaster";
            using (var connection = _context.CreateConnection())
            {
                var segment = await connection.QueryAsync<SegmentMasterModel>(query);
                segmentMasterModels = segment.ToList();
            }
            return segmentMasterModels;
        }

        public async Task<SegmentMasterModel> GetById(long Id)
        {
            SegmentMasterModel segment = new SegmentMasterModel();

            var query = "select * from tblsegmentmaster where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<SegmentMasterModel>(query, new { Id = Id });
                segment = result.FirstOrDefault();              
            }
            return segment;
        }
        public async Task<long> Add(SegmentMasterModel model)
        {
            long result = 0;
            long resultResult = 0;
            model.CreatedDate = DateTime.Now;

            var query = @"insert into tblsegmentmaster(SegmentName,StartPoints,EndPoints,Midpoints,CreatedBy,CreatedDate,isDeleted,Timestamp)
                        values (@SegmentName,@StartPoints,@EndPoints,@Midpoints,@CreatedBy,now(),0,now()) 
                       ";

            using (var connection = _context.CreateConnection())
            {
                var SegmentNameCondition = await connection.QueryAsync
                    (@"select Id from tblsegmentmaster where SegmentName=@SegmentName and isDeleted=0",
                    new { SegmentName = model.SegmentName });
                var FirstDocumentTypeById = SegmentNameCondition.FirstOrDefault();
                if (FirstDocumentTypeById != null)
                {
                    return -1;
                }
                result = await connection.ExecuteAsync(query, model);
                if (result >= 1)
                {
                    resultResult = result;
                }
                return result;
            }
          
        }

        public async Task<long> Update(SegmentMasterModel model)
        {

            long result = 0;

            model.ModifiedDate = DateTime.Now;

            var query = @"update tblsegmentmaster set SegmentName=@SegmentName,StartPoints=@StartPoints,EndPoints=@EndPoints,Midpoints=@Midpoints,
                          Modifiedby=@Modifiedby,ModifiedDate=now(),Timestamp=now() where Id=@Id";

            using (var connection = _context.CreateConnection())
            {
                var SegmentNameCondition = await connection.QueryAsync
                    (@"select Id from tblsegmentmaster where SegmentName=@SegmentName and isDeleted=0",
                    new { SegmentName = model.SegmentName });
                var FirstDocumentTypeById = SegmentNameCondition.FirstOrDefault();
                if (FirstDocumentTypeById != null)
                {
                    return -1;
                }
                result = await connection.ExecuteAsync(query, model);
               
                return result;
            }
            
        }

        public async Task<long> Delete(long id)
        {
            int result = 0;

            var query = @"delete from tblsegmentmaster
                          WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query,new { Id = id });
                return result;
            }
        }        

      
    }
}
