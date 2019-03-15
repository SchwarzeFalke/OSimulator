using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_3
{
    class Task
    {
        private int id;
        private int tme;
        private int tiempoAtendido;
        private int tiempoTranscurrido;
        private int tiempoLlegada;
        private int tiempoFinalizacion;
        private int tiempoRespuesta;
        private int tiempoRespuesta2;
        private int tiempoBloqueadoTranscurrido;
        private int tiempoBloqueadoTotal;

        private String operacion;
        private string status = "Nuevo";
        

        public Task(int id, String operacion, int tme)
        {
            this.tiempoAtendido = 0;
            this.id = id;
            this.operacion = operacion;
            this.tme = tme;
            this.tiempoTranscurrido = 0;
        }

        public Task(int id, Random rand)
        {
            this.id = id;
            this.operacion = this.autoOperation(rand);
            this.tme = this.autoTime(rand);
            this.tiempoTranscurrido = 0;
            this.tiempoLlegada = 0;
            this.tiempoFinalizacion = 0;
            this.tiempoRespuesta = -1;
            this.tiempoBloqueadoTranscurrido = 0;
            this.tiempoBloqueadoTotal = 10;
        }

        public Task()
        {
            this.id = 0;
            //this.operacion = "";
            this.tme = 0;
        }
        
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Operacion
        {
            get { return this.operacion; }
            set { this.operacion = value; }
        }

        public int TME
        {
            get { return this.tme; }
            set { this.tme = value; }
        }

        public int TiempoTranscurrido
        {
            get { return this.tiempoTranscurrido; }
            set { this.tiempoTranscurrido = value; }
        }

        public int TiempoRestante
        {
            get { return this.tme - this.tiempoTranscurrido; }
        }

        public int TiempoAtendido
        {
            get { return this.tiempoAtendido; }
            set { this.tiempoAtendido += value; }
        }

        public int TiempoLlegada
        {
            get { return this.tiempoLlegada; }
            set { this.tiempoLlegada = value; }
        }

        public int TiempoFinalizacion
        {
            get { return this.tiempoFinalizacion; }
            set { this.tiempoFinalizacion = value; }
        }

        public int TiempoRespuesta
        {
            get { return this.tiempoRespuesta; }
            set
            {
                if (this.tiempoRespuesta == -1)
                {
                    this.tiempoRespuesta = value - this.tiempoLlegada;
                    this.tiempoAtendido += this.tiempoRespuesta;
                }
            }
        }

        public int TiempoRespuesta2
        {
            get { return this.tiempoRespuesta2; }
            set { this.tiempoRespuesta2 += value; }
        }

        public int TiempoEspera
        {
            get { return this.TiempoRetorno - this.TiempoServicio; }
        }

        public int TiempoServicio
        {
            get { return this.tiempoTranscurrido; }
        }

        public int TiempoRetorno
        {
            get { return this.tiempoFinalizacion - this.tiempoLlegada; }
        }

        public int TiempoBloqueadoTranscurrido
        {
            get { return this.tiempoBloqueadoTranscurrido; }
            set { this.tiempoBloqueadoTranscurrido = value; }
        }

        public string Estado
        {
            get { return this.status; }
        }

        public bool Increment()
        {
            if (this.tiempoTranscurrido <= tme - 1)
            {
                this.tiempoTranscurrido++;
                return true;
            }
            return false;
        }

        public bool IncrementBloqued()
        {
            if (this.tiempoBloqueadoTranscurrido < this.tiempoBloqueadoTotal - 1)
            {
                this.tiempoBloqueadoTranscurrido++;
                return true;
            }
            return false;
        }

        private int autoTime(Random rand)
        {
            return rand.Next(7, 21);
        }

        private string autoOperation(Random rand)
        {
            string[] operations = new string[] { "+", "-", "*", "/", "%" };
            return (rand.Next(1001) + 1).ToString() + operations[rand.Next(5)] + (rand.Next(1001) + 1).ToString();
        }

        public float Resultado()
        {
            if (this.operacion.Contains("+"))
            {
                var split = this.operacion.Split("+".ToCharArray());
                int var1 = Int32.Parse(split[0]);
                int var2 = Int32.Parse(split[1]);
                float resultado = var1 + var2;
                return resultado;
            }
            if (this.operacion.Contains("-"))
            {
                var split = this.operacion.Split("-".ToCharArray());
                int var1 = Int32.Parse(split[0]);
                int var2 = Int32.Parse(split[1]);
                float resultado = var1 - var2;
                return resultado;
            }
            if (this.operacion.Contains("*"))
            {
                var split = this.operacion.Split("*".ToCharArray());
                int var1 = Int32.Parse(split[0]);
                int var2 = Int32.Parse(split[1]);
                float resultado = var1 * var2;
                return resultado;
            }
            if (this.operacion.Contains("/"))
            {
                var split = this.operacion.Split("/".ToCharArray());
                int var1 = Int32.Parse(split[0]);
                int var2 = Int32.Parse(split[1]);
                float resultado = (float)var1 / (float)var2;
                return resultado;
            }
            if (this.operacion.Contains("%"))
            {
                var split = this.operacion.Split("%".ToCharArray());
                int var1 = Int32.Parse(split[0]);
                int var2 = Int32.Parse(split[1]);
                float resultado = var1 % var2;
                return resultado;
            }
            return 0;
        }

        public object[] toReadyObject()
        {
            object[] values = new object[3];
            values[0] = id;
            values[1] = tme;
            values[2] = TiempoRestante;
            return values;
        }

        public object[] toExecObject()
        {
            object[] values = new object[5];
            values[0] = id;
            values[1] = operacion;
            values[2] = tme;
            values[3] = TiempoTranscurrido;
            values[4] = TiempoRestante;
            return values;
        }

        public object[] toFinishedObject()
        {
            object[] values = new object[3];
            values[0] = this.id;
            values[1] = this.operacion;
            values[2] = Resultado().ToString();
            /*
            values[3] = this.tiempoLlegada;
            values[4] = this.tiempoFinalizacion;
            values[5] = this.TiempoRetorno;
            values[6] = this.tiempoRespuesta;
            values[7] = this.TiempoEspera;
            values[8] = this.TiempoServicio;
            */
            return values;
        }

        public object[] toErrorObject()
        {
            object[] values = new object[3];
            values[0] = this.id;
            values[1] = this.operacion;
            values[2] = "Error";
            /*
            values[3] = this.tiempoLlegada;
            values[4] = this.tiempoFinalizacion;
            values[5] = this.TiempoRetorno;
            values[6] = this.tiempoRespuesta;
            values[7] = this.TiempoEspera;
            values[8] = this.TiempoServicio;
            */
            return values;
        }

        public object[] toBloquedObject()
        {
            object[] values = new object[2];
            values[0] = this.id;
            values[1] = this.tiempoBloqueadoTranscurrido;
            return values;
        }

        public void SetFinished() { this.status = "Terminado"; }
        public void SetError() { this.status = "Terminado por error"; }
        public void SetReady() { this.status = "Listo"; }
        public void SetExec() { this.status = "En ejecución"; }
        public void SetBlocked() { this.status = "Bloqueado"; }
    }
}
