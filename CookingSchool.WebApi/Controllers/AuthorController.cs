using System.Collections.Generic;
using System.Web.Http;
using CookingSchool.DAL.Repositories;
using CookingSchool.DAL.Models;
using CookingSchool.WebApi.Models;
using AutoMapper;
using CookingSchool.WebApi.Utils;

namespace CookingSchool.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("authors")]
    public class AuthorController : ApiController
    {
        private IMapper _mapper;
        private IRepository<Author> _authorRepository;
        public AuthorController(IRepository<Author> repository, IMapper mapper)
        {
            _authorRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        //[AuthorizeScope("read")]
        public IHttpActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAll();

            List<AuthorDto> authorsDtos = new List<AuthorDto>();

            _mapper.Map(authors, authorsDtos);

            return Ok(authorsDtos);
        }

        [HttpGet]
        [Route("{id}")]
        //[AuthorizeScope("read")]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = _authorRepository.GetById(id);

            AuthorDto authorDto = new AuthorDto();

            _mapper.Map(author, authorDto);

            return Ok(authorDto);
        }

        [HttpDelete]
        [Route("{id}")]
        //[AuthorizeScope("write")]
        public IHttpActionResult DeleteAuthor(int id)
        {
            var ingredient = _authorRepository.GetById(id);

            _authorRepository.Delete(ingredient);

            return Ok("");
        }

        [HttpPost]
        [Route ("")]
        //[AuthorizeScope("write")]
        public IHttpActionResult Post(AddAuthorViewModel model)
        {

            var author = new Author { Name = model.Name, Surname = model.Surname, Age = model.Age, City = model.City, Job = model.Job };

            _authorRepository.Add(author);

            return Ok(author.Id);
        }

        [HttpPut]
        [Route("")]
        //[AuthorizeScope("write")]
        public IHttpActionResult Update(EditAuthorViewModel model)
        {
            var author = _authorRepository.GetById(model.Id);

            _mapper.Map(author, model);

            _authorRepository.Update(author);

            return Ok($"You have updated author {author.Name} {author.Surname}");

        }

    }
}
