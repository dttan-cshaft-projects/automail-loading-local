using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AutoloadDTO
    {
        private int ID;
        private string DATE_YMD;
        private string TIME_HH;
        private string STATUS;
        private string LOGDATA;
        private string FUNC;
        private string EMPTY;
        private DateTime CREATEDDATE;

        public int autoloadID
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public string autoloadDateYMD
        {
            get
            {
                return DATE_YMD;
            }

            set
            {
                DATE_YMD = value;
            }
        }

        public string autoloadTimeHH
        {
            get
            {
                return TIME_HH;
            }

            set
            {
                TIME_HH = value;
            }
        }

        public string autoloadStatus
        {
            get
            {
                return STATUS;
            }

            set
            {
                STATUS = value;
            }
        }

        public string autoloadLogData
        {
            get
            {
                return LOGDATA;
            }

            set
            {
                LOGDATA = value;
            }
        }

        public string autoloadFunc
        {
            get
            {
                return FUNC;
            }

            set
            {
                FUNC = value;
            }
        }

        public string autoloadEmpty
        {
            get
            {
                return EMPTY;
            }

            set
            {
                EMPTY = value;
            }
        }

        public DateTime autoloadCreateddate
        {
            get
            {
                return CREATEDDATE;
            }

            set
            {
                CREATEDDATE = value;
            }
        }

        // constructor
        public AutoloadDTO()
        {

        }

        public AutoloadDTO(int Id, string DateYMD, string TimeHH, string Status, string LogData, string Func, string Empty )
        {
            this.autoloadID = Id;
            this.autoloadDateYMD = DateYMD;
            this.autoloadTimeHH = TimeHH;
            this.autoloadStatus = Status;
            this.autoloadLogData = LogData;
            this.autoloadFunc = Func;
            this.autoloadEmpty = Empty;
        }

    }
}
