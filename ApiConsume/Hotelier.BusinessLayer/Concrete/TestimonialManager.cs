using Hotelier.BusinessLayer.Abstract;
using Hotelier.DataAccessLayer.Abstract;
using Hotelier.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelier.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        void IGenericService<Testimonial>.TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        Testimonial IGenericService<Testimonial>.TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        List<Testimonial> IGenericService<Testimonial>.TGetList()
        {
            return _testimonialDal.GetList();
        }

        void IGenericService<Testimonial>.TInsert(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        void IGenericService<Testimonial>.TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
