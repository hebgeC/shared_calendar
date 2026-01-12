using System.Reflection.Metadata;

namespace shared_calendar.Models
{
    public class EventCollisionTree
    {
        public EventCollisionTree()
        {
            this.root = new();
        }

        private Node root;

        public void Add(CalendarEvent e)
        {
            if (root == null)
            {
                root = new Node(e);
                return;
            }

            this.add(e, this.root);
        }

        public void AddEnumerable(IEnumerable<CalendarEvent> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        private void add(CalendarEvent e, Node root)
        {
            // check if events collide
            if (
                e.StartDateTime.CompareTo(this.root.Event.StartDateTime) >= 0 && e.StartDateTime.CompareTo(this.root.Event.EndDateTime) <= 0 ||
                e.EndDateTime.CompareTo(this.root.Event.EndDateTime) <= 0 && e.EndDateTime.CompareTo(this.root.Event.StartDateTime) >= 0
                )
            {
                // events collide
                // check if left child is null
                if (root.Left == null)
                {
                    root.Left = new Node(e);
                }
                else
                {
                    this.add(e, root.Left);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node(e);
                }
                else
                {
                    this.add(e, root.Right);
                }
            }
        }

        /// <summary>
        /// returns a list of lists of event id's. each 
        /// list holds the events that collide with each other
        /// </summary>
        /// <returns>lists of colliding events by id</returns>
        public List<List<int>> GetEventCollisions()
        {
            List<List<int>> list = new List<List<int>>();
            this.getEventCollisions(this.root, list, 0);
            return list;
        }

        private void getEventCollisions(Node? root, List<List<int>> list, int index)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left != null)
            {
                list[index].Add(root.Event.id);
                this.getEventCollisions(root.Left, list, index);
            }

            // traveresed as far left on current branch
            this.getEventCollisions(root.Right, list, ++index);
            return;
        }
    }

    internal class Node
    {
        public Node(CalendarEvent e)
        {
            this.Event = e;
        }

        public Node()
        {
            this.Event = new();
        }

        public CalendarEvent Event { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}
