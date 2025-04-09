using ElevatorPriorityDemo.Properties;
using My_Own_Custom_Controls_library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorPriorityDemo
{
    public partial class ElevatorRoom : Form
    {
        public class FloorPriority
        {
            public string Name { get; set; }
            public int Priority { get; set; }

            public FloorPriority(string name, int priority)
            {
                Name = name;
                Priority = priority;
            }
        }
        public class MinHeapPriorityQueue
        {
            private List<FloorPriority> heap = new List<FloorPriority>();
            public int Count { get { return heap.Count; } }

            // Insert a new element with a priority
            public void Insert(string name, int priority)
            {
                var node = new FloorPriority(name, priority);
                heap.Add(node);
                HeapifyUp(heap.Count - 1);
            }

            // Extract the element with the minimum priority
            public FloorPriority ExtractMin()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                var minNode = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                HeapifyDown();

                return minNode;
            }

            // Peek at the element with the minimum priority without removing it
            public FloorPriority Peek()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                return heap[0];
            }

            // Helper method to restore the heap property by bubbling up
            private void HeapifyUp(int index)
            {
                while (index > 0)
                {
                    int parentIndex = (index - 1) / 2;

                    if (heap[index].Priority >= heap[parentIndex].Priority) break;

                    (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                    index = parentIndex;
                }
            }

            // Helper method to restore the heap property by bubbling down
            private void HeapifyDown(int index = 0)
            {
                while (index < heap.Count)
                {
                    int leftChildIndex = 2 * index + 1;
                    int rightChildIndex = 2 * index + 2;
                    int smallestIndex = index;

                    if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                        smallestIndex = leftChildIndex;

                    if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                        smallestIndex = rightChildIndex;

                    if (smallestIndex == index) break;

                    (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
                    index = smallestIndex;
                }
            }

        }
        public class MaxHeapPriorityQueue
        {
            private List<FloorPriority> heap = new List<FloorPriority>();
            public int Count { get { return heap.Count; } }
            // Insert a new element with a priority
            public void Insert(string name, int priority)
            {
                var node = new FloorPriority(name, priority);
                heap.Add(node);
                HeapifyUp(heap.Count - 1);
            }

            // Extract the element with the minimum priority
            public FloorPriority ExtractMax()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                var Max = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                HeapifyDown();

                return Max;
            }

            // Peek at the element with the minimum priority without removing it
            public FloorPriority Peek()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                return heap[0];
            }

            // Helper method to restore the heap property by bubbling up
           
            private void HeapifyUp(int index)
            {
                while (index > 0)
                {
                    int parentIndex = (index - 1) / 2;

                    if (heap[index].Priority <= heap[parentIndex].Priority) break;

                    (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                    index = parentIndex;
                }
            }

            // Helper method to restore the heap property by bubbling down
            private void HeapifyDown(int index = 0)
            {
                while (index < heap.Count)
                {
                    int leftChildIndex = 2 * index + 1;
                    int rightChildIndex = 2 * index + 2;
                    int smallestIndex = index;

                    if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority > heap[smallestIndex].Priority)
                        smallestIndex = leftChildIndex;

                    if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority > heap[smallestIndex].Priority)
                        smallestIndex = rightChildIndex;

                    if (smallestIndex == index) break;

                    (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
                    index = smallestIndex;
                }
            }

        }
        public class PriorityQueue
        {
            public enum _PriorityQueueMode { Min, Max }
            private _PriorityQueueMode _mode = _PriorityQueueMode.Min;
            public PriorityQueue(_PriorityQueueMode mode)
            {
                _mode = mode;
            }
            private List<FloorPriority> heap = new List<FloorPriority>();
            public int Count { get { return heap.Count; } }

            // Insert a new element with a priority
            public void Insert(string name, int priority)
            {
                var node = new FloorPriority(name, priority);
                heap.Add(node);
                HeapifyUp(heap.Count - 1);
            }

            // Extract the element with the minimum priority
            public FloorPriority Extract()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                var Value = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                HeapifyDown();

                return Value;
            }

            // Peek at the element with the minimum priority without removing it
            public FloorPriority Peek()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("Priority Queue is empty.");
                }

                return heap[0];
            }

            // Helper method to restore the heap property by bubbling up
            private void HeapifyUp(int index)
            {
                if (_mode == _PriorityQueueMode.Min)
                {
                    while (index > 0)
                    {
                        int parentIndex = (index - 1) / 2;

                        if (heap[index].Priority >= heap[parentIndex].Priority) break;
                        else
                            (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

                        index = parentIndex;
                    }
                }
                else
                {
                    while (index > 0)
                    {
                        int parentIndex = (index - 1) / 2;

                        if (heap[index].Priority <= heap[parentIndex].Priority) break;
                        else
                            (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

                        index = parentIndex;
                    }
                }
            }

            // Helper method to restore the heap property by bubbling down
            private void HeapifyDown(int index = 0)
            {
                while (index < heap.Count)
                {
                    int leftChildIndex = 2 * index + 1;
                    int rightChildIndex = 2 * index + 2;
                    int smallestIndex = index;

                    if (_mode == _PriorityQueueMode.Min)
                    {
                        if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                            smallestIndex = leftChildIndex;

                        if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                            smallestIndex = rightChildIndex;
                    }
                    else
                    {
                        if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority > heap[smallestIndex].Priority)
                            smallestIndex = leftChildIndex;

                        if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority > heap[smallestIndex].Priority)
                            smallestIndex = rightChildIndex;
                    }

                    if (smallestIndex == index) break;

                    (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
                    index = smallestIndex;
                }
            }

        }
        public ElevatorRoom()
        {
            InitializeComponent();
        }

        enum ElevatorDirection { Up, Down }
        ElevatorDirection ElevatorMove = ElevatorDirection.Up;

        MinHeapPriorityQueue minHeapPriorityQueue = new MinHeapPriorityQueue();
        MaxHeapPriorityQueue maxHeapPriorityQueue = new MaxHeapPriorityQueue();
        private int Count = 0;
        private List<CircularButton> BtnList = new List<CircularButton>();

        
        private void ElevatorRoom_Load(object sender, EventArgs e)
        {
            B0.Enabled = false;
            FillButtonsInForm();
        }
        private void FillButtonsInForm()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is CircularButton)
                {
                    if (ctrl.Tag != null)
                        BtnList.Add(ctrl as CircularButton);
                }
            }
        }
        private void DisableFloorButtons()
        {
            BtnList.ForEach(btn => btn.Enabled = false);
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var Btn = sender as Button;

            if (rchTxt.Text == string.Empty)
                rchTxt.Text += Btn.Text;
            else
                rchTxt.Text += " ," + Btn.Text;

            if (ElevatorMove == ElevatorDirection.Up)
                minHeapPriorityQueue.Insert(Btn.Tag.ToString(), Convert.ToInt32(Btn.Text));
            else
                maxHeapPriorityQueue.Insert(Btn.Tag.ToString(), Convert.ToInt32(Btn.Text));

            Btn.Enabled = false;
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            FloorTimer.Start();
            BtnDemand.Enabled = false;
            _elevatorMovingSound.Play();
            DisableFloorButtons();
        }
        private void _HandleElevatorDirection()
        {
            // Change Elevator Direction + Change the Pic.
            if (ElevatorMove == ElevatorDirection.Up)
            {
                ElevatorMove = ElevatorDirection.Down;
                pbUpDown.Image = Resources.down;
            }
            else
            {
                ElevatorMove = ElevatorDirection.Up;
                pbUpDown.Image = Resources.up_2;
            }
        }
        /// <summary>
        /// Disable All Buttons That Have Number Grater Than the Current Floor,
        /// OtherWays Enable Them When the elevator goes up. the opposite happens When the elevator goes down.
        /// </summary>
        private void HandleFloorAccess()
        {

            int CurrentFloor = Convert.ToInt32(txtFloors.Text);

            if (ElevatorMove == ElevatorDirection.Up)
            {
                foreach (var btn in BtnList)
                {
                    if (btn.Tag != null && Convert.ToInt32(btn.Text) >= CurrentFloor)
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }            
            }
            else
            {
                foreach (var btn in BtnList)
                {
                    if (btn.Tag != null && Convert.ToInt32(btn.Text) <= CurrentFloor)
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
            }
           
            _HandleElevatorDirection();

            rchTxt.Text = string.Empty;
        }
        public SoundPlayer ElevatorDing = new SoundPlayer(@"C:\Users\ULTRAPC\OneDrive\Bureau\elevator-dingwav-14913 (online-audio-converter.com).wav");
        private SoundPlayer _elevatorMovingSound = new SoundPlayer(@"C:\Users\ULTRAPC\OneDrive\Bureau\elevator-33034 (online-audio-converter.com).wav");

        private async void FloorTimer_Tick(object sender, EventArgs e)
        {
            txtFloors.Text = Count.ToString();
            FloorTimer.Stop();

            try
            {
                if (ElevatorMove == ElevatorDirection.Up)
                {
                    if (minHeapPriorityQueue.Count != 0 && minHeapPriorityQueue.Peek().Priority == Count)
                    {
                        lblNextFloor.Text = minHeapPriorityQueue.ExtractMin().Name;

                        _elevatorMovingSound.Stop();

                        cbtnDestReached.BackColor = Color.Green;
                        cbtnDestReached2.BackColor = Color.Green;

                        ElevatorDing.Play(); // Play arrival chime
                        await Task.Delay(3000); // Keep doors open

                        cbtnDestReached.BackColor = Color.Red;
                        cbtnDestReached2.BackColor = Color.Red;

                        _elevatorMovingSound.Play();

                    }

                    BtnDemand.Enabled = minHeapPriorityQueue.Count == 0;
                    if (minHeapPriorityQueue.Count != 0)
                        Count++;
                }
                else
                {
                    if (maxHeapPriorityQueue.Count != 0 && maxHeapPriorityQueue.Peek().Priority == Count)
                    {
                        lblNextFloor.Text = maxHeapPriorityQueue.ExtractMax().Name;

                        _elevatorMovingSound.Stop();

                        cbtnDestReached.BackColor = Color.Green;
                        cbtnDestReached2.BackColor = Color.Green;

                        ElevatorDing.Play(); // Play arrival chime
                        await Task.Delay(3000); // Keep doors open

                        cbtnDestReached.BackColor = Color.Red;
                        cbtnDestReached2.BackColor = Color.Red;

                        _elevatorMovingSound.Play();


                    }

                    BtnDemand.Enabled = maxHeapPriorityQueue.Count == 0;
                    if (maxHeapPriorityQueue.Count != 0)
                        Count--;
                }
            }
            finally
            {
                if (maxHeapPriorityQueue.Count != 0 || minHeapPriorityQueue.Count != 0)
                {
                    FloorTimer.Start();
                }
                else
                {
                    _elevatorMovingSound.Stop();
                    HandleFloorAccess();
                }
            }
        }

        private void BtnDemand_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtFloors.Text) != 0)
            {
                B0.PerformClick();
                BtnGo.PerformClick();
            }
        }
    }
}
