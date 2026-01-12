using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Application
{

    /// <summary>
    /// enMode , Save are implemented ||
    /// _Add , _Update must be implemented ||
    /// Delete , GetById , GetAll must be created in parent class
    /// </summary>
    public abstract class clsEntity
    {

        protected enum enMode { Add, Update }
        protected enMode _Mode;

        


        public virtual bool Save()
        {
            switch (_Mode)
            {

                case enMode.Add:
                    if (_Add())
                    {
                        _Mode = enMode.Update;
                        
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        protected abstract bool _Add();

        protected abstract bool _Update();
        




    }


        
}
