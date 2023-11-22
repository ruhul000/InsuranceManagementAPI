using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Extensions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace InsuranceManagementAPI.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly PolicyDBContext _context;

        public ClientRepository(PolicyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            //return await _context.Clients.Where(p => p.ClientName.StartsWith("As")).ToListAsync().Take(10);
            return await _context.Clients.Take(50).OrderBy(c => c.ClientName).ToListAsync();
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsByName(ClientDto clientDto)
        {
            String searchWord = "";
            if (clientDto.ClientName.StartsWith("%"))
            {
                searchWord = clientDto.ClientName.Substring(1, clientDto.ClientName.Length - 1);
                return await _context.Clients.Where(c => c.ClientName.Contains(searchWord)).OrderBy(c => c.ClientName).Take(50).ToListAsync();
            }
            else
            {
                searchWord = clientDto.ClientName;
                return await _context.Clients.Where(c => c.ClientName.StartsWith(searchWord)).OrderBy(c => c.ClientName).Take(50).ToListAsync();
            }
            
        }


        public async Task<ClientDto> GetClientByID(long id)
        {
            return await _context.Clients.FirstOrDefaultAsync(obj => obj.ClientKey == id);
        }
        public async Task<long> Add(ClientDto client)
        {
            //_context.Clients.Add(client);
            //var result = await _context.SaveChangesAsync();
            //return (result);

            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@ClientKey", SqlDbType = System.Data.SqlDbType.BigInt, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@BranchKey", Value = client.BranchKey });
            paramList.Add(new SqlParameter { ParameterName = "@ClientName", Value = client.ClientName.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientNameExtar", Value = client.ClientNameExtar.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientAddress", Value = client.ClientAddress.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientMobile", Value = client.ClientMobile.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientType", Value = client.ClientType.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientTypeTwo", Value = client.ClientTypeTwo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientSector", Value = client.ClientSector.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientVATNo", Value = client.ClientVATNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientBINNo", Value = client.ClientBINNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientTINNo", Value = client.ClientTINNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Client_VAT_Exemption", Value = client.Client_VAT_Exemption.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@GroupKey", Value = client.GroupKey.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientPhone", Value = client.ClientPhone.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientFax", Value = client.ClientFax.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientEMail", Value = client.ClientEMail.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientRelation", Value = client.ClientRelation.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientWeb", Value = client.ClientWeb.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientContractPer", Value = client.ClientContractPer.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientDesignation", Value = client.ClientDesignation.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@SpecDiscount", Value = client.SpecDiscount.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@EmpKeyDirectorRef", Value = client.EmpKeyDirectorRef.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Status", Value = client.Status.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_A", Value = client.Int_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_B", Value = client.Int_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_C", Value = client.Int_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_D", Value = client.Int_D.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_A", Value = client.Str_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_B", Value = client.Str_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_C", Value = client.Str_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_D", Value = client.Str_D.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_A", Value = client.Date_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_B", Value = client.Date_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_C", Value = client.Date_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = client.BackupType.ToDBNullIfNothing() });

            

            await _context.Database.ExecuteSqlRawAsync("EXECUTE AddClient @ClientKey OUT, @BranchKey, @ClientName, @ClientNameExtar, @ClientAddress, @ClientMobile, @ClientType, @ClientTypeTwo, " +
                "@ClientSector, @ClientVATNo, @ClientBINNo, @ClientTINNo, @Client_VAT_Exemption, @GroupKey, @ClientPhone, @ClientFax, @ClientEMail, @ClientRelation, @ClientWeb, @ClientContractPer, " +
                "@ClientDesignation, @SpecDiscount, @EmpKeyDirectorRef, @Status, @Int_A, @Int_B, @Int_C, @Int_D, @Str_A, @Str_B, @Str_C, @Str_D, @Date_A, @Date_B, @Date_C, @BackupType",
                paramList);

            var ClientKey = Convert.ToInt64(paramList[0].Value);
            return ClientKey;
        }

        public async Task<bool> Update(ClientDto client)
        {
            var paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });
            paramList.Add(new SqlParameter { ParameterName = "@ClientKey", Value = client.ClientKey });
            paramList.Add(new SqlParameter { ParameterName = "@BranchKey", Value = client.BranchKey });
            paramList.Add(new SqlParameter { ParameterName = "@ClientName", Value = client.ClientName.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientNameExtar", Value = client.ClientNameExtar.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientAddress", Value = client.ClientAddress.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientMobile", Value = client.ClientMobile.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientType", Value = client.ClientType.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientTypeTwo", Value = client.ClientTypeTwo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientSector", Value = client.ClientSector.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientVATNo", Value = client.ClientVATNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientBINNo", Value = client.ClientBINNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientTINNo", Value = client.ClientTINNo.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Client_VAT_Exemption", Value = client.Client_VAT_Exemption.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@GroupKey", Value = client.GroupKey.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientPhone", Value = client.ClientPhone.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientFax", Value = client.ClientFax.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientEMail", Value = client.ClientEMail.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientRelation", Value = client.ClientRelation.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientWeb", Value = client.ClientWeb.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientContractPer", Value = client.ClientContractPer.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@ClientDesignation", Value = client.ClientDesignation.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@SpecDiscount", Value = client.SpecDiscount.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@EmpKeyDirectorRef", Value = client.EmpKeyDirectorRef.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Status", Value = client.Status.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_A", Value = client.Int_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_B", Value = client.Int_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_C", Value = client.Int_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Int_D", Value = client.Int_D.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_A", Value = client.Str_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_B", Value = client.Str_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_C", Value = client.Str_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Str_D", Value = client.Str_D.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_A", Value = client.Date_A.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_B", Value = client.Date_B.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@Date_C", Value = client.Date_C.ToDBNullIfNothing() });
            paramList.Add(new SqlParameter { ParameterName = "@BackupType", Value = client.BackupType.ToDBNullIfNothing() });

            await _context.Database.ExecuteSqlRawAsync("EXECUTE UpdateClient @Result OUT, @ClientKey, @BranchKey, @ClientName, @ClientNameExtar, @ClientAddress, @ClientMobile, @ClientType, @ClientTypeTwo, " +
                "@ClientSector, @ClientVATNo, @ClientBINNo, @ClientTINNo, @Client_VAT_Exemption, @GroupKey, @ClientPhone, @ClientFax, @ClientEMail, @ClientRelation, @ClientWeb, @ClientContractPer, " +
                "@ClientDesignation, @SpecDiscount, @EmpKeyDirectorRef, @Status, @Int_A, @Int_B, @Int_C, @Int_D, @Str_A, @Str_B, @Str_C, @Str_D, @Date_A, @Date_B, @Date_C, @BackupType",
                paramList);

            var result = Convert.ToBoolean(paramList[0].Value);
            return result;
        }

        public async Task<bool> Remove(long clientKey)
        {
            ClientDto clientDto = new ClientDto { ClientKey = clientKey };
            _context.Clients.Remove(clientDto);
         
            return (_context.SaveChanges()>0);
        }
    }
}
