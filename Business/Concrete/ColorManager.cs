using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class ColorManager:IColorService {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal) {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll().OrderBy(c=>c.ColorId).ToList());
        }

        public IDataResult<Color> GetById(int colorId) {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IResult Add(Color color) {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Update(Color color) {
            _colorDal.Update(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color) {
            _colorDal.Delete(color);
            return new SuccessResult();
        }
    }
}