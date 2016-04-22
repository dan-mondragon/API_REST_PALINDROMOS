using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PalindromosWebApi;

namespace PalindromosWebApi.Controllers
{
    public class PalabrasController : ApiController
    {
        private PalindromoDevWebApiEntities db = new PalindromoDevWebApiEntities();

        // GET: api/Palabras
        public IQueryable<Palabra> GetPalabras()
        {
            return db.Palabras;
        }

        // GET: api/Palabras/5
        [ResponseType(typeof(Palabra))]
        public IHttpActionResult GetPalabra(int id)
        {
            Palabra palabra = db.Palabras.Find(id);
            if (palabra == null)
            {
                return NotFound();
            }

            return Ok(palabra);
        }

        // POST: api/Palabras
        [HttpPost]
        [ResponseType(typeof(Palabra))]
        public IHttpActionResult PostPalabra(Palabra_2 Palabra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int lastWordId = 0;
            if(db.Palabras.Find(1) != null)
            {
                lastWordId = db.Palabras.Max(item => item.Id);
            }
            
            Palabra pal = new Palabra();
            if (Palabra.Palabra1.ToUpper().Equals(invertir(Palabra.Palabra1.ToUpper())))
            {
                pal.Palindromo = true;
            }
            else
            {
                pal.Palindromo = false;
            }
            pal.Palabra1 = Palabra.Palabra1;
            pal.Id = lastWordId + 1;
            db.Palabras.Add(pal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pal.Id }, pal);
            //return Ok(pal);
        }

        private static string invertir(string frase)
        {
            string invertido = "";
            for (int i = frase.Length - 1; i >= 0; i--)
                invertido = invertido + frase.Substring(i, 1);
            return invertido;
        }

         //DELETE: api/Palabras/5
        [ResponseType(typeof(Palabra))]
        public IHttpActionResult DeletePalabra(int id)
        {
            Palabra palabra = db.Palabras.Find(id);
            if (palabra == null)
            {
                return NotFound();
            }

            db.Palabras.Remove(palabra);
            db.SaveChanges();

            return Ok(palabra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PalabraExists(int id)
        {
            return db.Palabras.Count(e => e.Id == id) > 0;
        }
    }
}