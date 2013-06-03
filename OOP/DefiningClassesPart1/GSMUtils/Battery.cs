using System;

namespace GSMUtils
{
    public class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType? type;

        public BatteryType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public Battery(string model)
            : this(model, null)
        {
        }

        public Battery(string model, int? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk)
            : this(model, hoursIdle, hoursTalk, null)
        {
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType? type)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.type = type;
        }
    }
}
