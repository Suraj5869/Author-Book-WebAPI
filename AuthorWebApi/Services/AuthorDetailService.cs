using AuthorWebApi.DTOs;
using AuthorWebApi.Exceptions;
using AuthorWebApi.Models;
using AuthorWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApi.Services
{
    public class AuthorDetailService : IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetail> _repository;
        private readonly IMapper _mapper;

        public AuthorDetailService(IRepository<AuthorDetail> authorDetailRepository, IMapper mapper)
        {
            _repository = authorDetailRepository;
            _mapper = mapper;
        }

        //Add author details in database
        public int AddAuthorDetails(AuthorDetailDto authorDetailDto)
        {
            var authorDetail = _mapper.Map<AuthorDetail>(authorDetailDto);
            _repository.Add(authorDetail);
            return authorDetail.Id;
        }

        //Delete author details from database
        public bool DeleteAuthorDetails(int id)
        {
            var authorDetail = _repository.Get(id);
            if (authorDetail == null)
            {
                throw new AuthorDetailsNotFoundException("No such author details found");
            }
            _repository.Delete(authorDetail);
            return true;
        }

        //Get author details from database
        public List<AuthorDetailDto> GetAuthorDetails()
        {
            var details = _repository.GetAll().Include(a => a.Author).ToList();
            List<AuthorDetailDto> detailDtos = _mapper.Map<List<AuthorDetailDto>>(details);
            return detailDtos;
        }

        //Get author details from database using id

        public AuthorDetailDto GetById(int id)
        {
            AuthorDetail authorDetail = _repository.Get(id);
            if (authorDetail == null)
                throw new AuthorDetailsNotFoundException("No such suthor details found");
            AuthorDetailDto authorDetailDto = _mapper.Map<AuthorDetailDto>(authorDetail);
            return authorDetailDto;
        }

        //update author details available in database
        public bool UpdateAuthorDetails(AuthorDetailDto authorDetailDto)
        {
            var existingDetails = _repository.GetAll().AsNoTracking().FirstOrDefault(b => b.Id == authorDetailDto.Id);
            AuthorDetail authorDetail = _mapper.Map<AuthorDetail>(authorDetailDto);

            if (existingDetails == null)
            {
                throw new AuthorDetailsNotFoundException("No such author details found");
            }
            _repository.Update(authorDetail);
            return true;
        }

        //Get author details using author id
        public AuthorDetailDto GetByAuthorId(int authorId)
        {
            var authorDetails = _repository.GetAll().Where(a => a.AuthorId == authorId).FirstOrDefault();
            if (authorDetails == null)
                throw new AuthorDetailsNotFoundException("No such author details found");
            AuthorDetailDto authorDetail = _mapper.Map<AuthorDetailDto>(authorDetails);
            return authorDetail;
        }
    }
}
