using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchInterrupt
{
    public class Batch
    {
        private readonly Queue<Task> processes = new Queue<Task>();
        private readonly int id;

        public Batch() { }

        public Batch(int id)
        {
            this.id = id;
        }

        public void AppendTask(Task process)
        {
            this.processes.Enqueue(process);
        }

        public Queue<Task> Processes()
        {
            return this.processes;
        }
    }
}
