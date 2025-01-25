using AutoMapper;
using Jobs.Core.Constants;
using Jobs.Core.DTOs;
using Jobs.Core.Enums;
using Jobs.Core.Interfaces;
using Jobs.Core.Interfaces.Services;
using Jobs.Core.Models;

namespace Jobs.EF.Services
{
    public class JobService : IJobsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ResponseDTO ListJobs()
        {
            IEnumerable<Position> Jobs = _unitOfWork.Repository<Position>().GetAll();
            return new ResponseDTO(ResponseStatusCode.Ok, true, _mapper.Map<IEnumerable<PositionDTO>>(Jobs), "All Positions");
        }

        public ResponseDTO ViewDetails(int ID)
        {
            Position Job = _unitOfWork.Repository<Position>().Find(j => j.ID == ID);
            if(Job is not null)
            {
                return new ResponseDTO(ResponseStatusCode.Ok, true, _mapper.Map<PositionDTO>(Job), "Position Details");
            }
            else
            {
                return new ResponseDTO(ResponseStatusCode.NotFound, true, null, "there is no position with this ID");
            }
        }


        public async Task<ResponseDTO> Apply(PositionApplicationsDTO positionApplicationsDTO)
        {
            ResponseDTO result;

            bool jobExists = _unitOfWork.Repository<Position>().IsExist(c => c.ID == positionApplicationsDTO.PositionID);

            if (jobExists)
            {
                result = await RegisterApplication(positionApplicationsDTO);
            }
            else
            {
                result = await JobNotFount();
            }

            return result;
        }

        public async Task<ResponseDTO> RegisterApplication(PositionApplicationsDTO positionApplicationsDTO)
        {
            bool isCVAccepted = SaveFile(positionApplicationsDTO, FolderNames.CVs);
            if (!isCVAccepted)
            {
                return new ResponseDTO(ResponseStatusCode.ServerError, false, positionApplicationsDTO, "There is issue with your CV proccessing Check your CV file format");
            }
            PositionApplication positionApplication = await InsertRecoredToDB(positionApplicationsDTO);
            return new ResponseDTO(ResponseStatusCode.Ok, true, positionApplication, "Your Applicatation Registered");
        }

        private async Task<PositionApplication> InsertRecoredToDB(PositionApplicationsDTO positionApplicationsDTO)
        {
            PositionApplication positionApplication = _mapper.Map<PositionApplication>(positionApplicationsDTO);
            _unitOfWork.Repository<PositionApplication>().Add(positionApplication);
            await _unitOfWork.SaveChangesAsync();
            return positionApplication;
        }

        private bool SaveFile(PositionApplicationsDTO positionApplicationsDTO, string folderName)
        {
            bool isSuccess = true;
            try
            {
                byte[] cvBytes = Convert.FromBase64String(positionApplicationsDTO.CV);
                positionApplicationsDTO.DbFilename = Guid.NewGuid().ToString() + Path.GetExtension(positionApplicationsDTO.ClientFileName);

                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                File.WriteAllBytes($"{folderName}\\{positionApplicationsDTO.DbFilename}", cvBytes);
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public async Task<ResponseDTO> JobNotFount()
        {
            return new ResponseDTO(ResponseStatusCode.NotFound, false, new PositionDTO(), "there is no position with this ID");
        }

    }
}
