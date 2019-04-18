namespace EventImplementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public Dispatcher() { }

        public string Name
        {
            get => this.name;
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            if(this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }
    }
}
