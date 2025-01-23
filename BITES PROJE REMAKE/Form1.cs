// MainForm.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace BITES_PROJE_REMAKE
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Graf verilerini tutacak değişkenler
        private int numNodes;
        private List<int>[] graph;
        private int[,] weights;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler burada olacak
            // ComboBox'a algoritma isimlerini ekleyin
            comboBoxAlgorithm.Items.Add("Bellman-Ford");
            comboBoxAlgorithm.Items.Add("Dijkstra");
            comboBoxAlgorithm.Items.Add("Prim");
            comboBoxAlgorithm.Items.Add("Kruskal");

            // İlk seçeneği varsayılan olarak seçin
            comboBoxAlgorithm.SelectedIndex = 0;
        }

        // TreeView güncelleme fonksiyonu
        private void UpdateTreeView()
        {
            // Kullanıcının girdiği graf verilerini alın ve TreeView kontrolüne ekle
            treeView.Nodes.Clear();

            for (int i = 0; i < numNodes; i++)
            {
                TreeNode node = new TreeNode($"Node {i}");

                // Eğer düğümün kenarları varsa, onları da ekleyin
                for (int j = 0; j < numNodes; j++)
                {
                    if (i != j && weights[i, j] > 0)
                    {
                        TreeNode edge = new TreeNode($"Node {j} - Weight: {weights[i, j]}");
                        node.Nodes.Add(edge);
                    }
                }

                treeView.Nodes.Add(node);
            }

            // Ağacı genişletin
            treeView.ExpandAll();
        }


        private void btnCreateGraph_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği düğüm sayısını alın
            if (!int.TryParse(txtNumNodes.Text, out numNodes) || numNodes <= 0)
            {
                MessageBox.Show("Please enter a valid Node!");
                return;
            }

            // Graf verilerini oluşturma ve TreeView güncelleme
            graph = new List<int>[numNodes];
            weights = new int[numNodes, numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                graph[i] = new List<int>();
            }

            UpdateWeightsArray();

            // TreeView güncelleme
            UpdateTreeView();

            MessageBox.Show("Graph created and added to TreeView!");
        }

        // Method to handle weight input form and update the weights array
        private void UpdateWeightsArray()
        {
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = i + 1; j < numNodes; j++)
                {
                    int weight;
                    using (var weightInputForm = new WeightInputForm(i, j))
                    {
                        if (weightInputForm.ShowDialog() == DialogResult.OK)
                        {
                            weight = weightInputForm.Weight;
                        }
                        else
                        {
                            MessageBox.Show("Weight is not valid, it will be accepted 0.");
                            weight = 0;
                        }
                        // Update the weights array
                        weights[i, j] = weights[j, i] = weight;
                    }
                }
            }
        }





        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            int selectedAlgorithm = comboBoxAlgorithm.SelectedIndex;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            switch (selectedAlgorithm)
            {
                case 0:
                    // Bellman-Ford Algoritması
                    int sourceNodeBF = 0;
                    BellmanFordAlgorithm(sourceNodeBF);
                    break;
                case 1:
                    // Dijkstra Algoritması
                    int sourceNodeDijkstra = 0;
                    DijkstraAlgorithm(sourceNodeDijkstra);
                    break;
                case 2:
                    // Prim Algoritması
                    PrimAlgorithm();
                    break;
                case 3:
                    // Kruskal Algoritması
                    KruskalAlgorithm();
                    break;
                default:
                    MessageBox.Show("Please choose Algorithm!");
                    break;
            }

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            dataGridView.Rows.Add(comboBoxAlgorithm.SelectedItem, $"{elapsed.TotalSeconds} seconds");
        }

        // Bellman-Ford Algoritması
        private void BellmanFordAlgorithm(int sourceNode)
        {
            int[] distances = new int[numNodes];
            int[] prevNodes = new int[numNodes];

            // Başlangıç durumunu ayarla
            for (int i = 0; i < numNodes; i++)
            {
                distances[i] = int.MaxValue;
                prevNodes[i] = -1;
            }
            distances[sourceNode] = 0;

            // Bellman-Ford algoritması uygulama
            for (int i = 0; i < numNodes - 1; i++)
            {
                for (int u = 0; u < numNodes; u++)
                {
                    for (int v = 0; v < numNodes; v++)
                    {
                        if (weights[u, v] > 0 && distances[u] != int.MaxValue && distances[u] + weights[u, v] < distances[v])
                        {
                            distances[v] = distances[u] + weights[u, v];
                            prevNodes[v] = u;
                        }
                    }
                }
            }

            // Sonuçları göster
            string result = "Bellman-Ford Algorithm Results:\n";
            for (int i = 0; i < numNodes; i++)
            {
                if (distances[i] == int.MaxValue)
                    result += $"Node {i}: Cannot be reachable\n";
                else
                    result += $"Node {i}: Shortest Path = {distances[i]}, Prev Node = {prevNodes[i]}\n";
            }

            MessageBox.Show(result);
        }

        // Dijkstra Algoritması
        private void DijkstraAlgorithm(int sourceNode)
        {
            int[] distances = new int[numNodes];
            int[] prevNodes = new int[numNodes];
            bool[] visited = new bool[numNodes];

            // Başlangıç durumunu ayarla
            for (int i = 0; i < numNodes; i++)
            {
                distances[i] = int.MaxValue;
                prevNodes[i] = -1;
                visited[i] = false;
            }
            distances[sourceNode] = 0;

            // Dijkstra algoritması uygulama
            for (int i = 0; i < numNodes - 1; i++)
            {
                int u = -1;
                for (int j = 0; j < numNodes; j++)
                {
                    if (!visited[j] && (u == -1 || distances[j] < distances[u]))
                    {
                        u = j;
                    }
                }

                if (distances[u] == int.MaxValue)
                    break;

                visited[u] = true;

                for (int v = 0; v < numNodes; v++)
                {
                    if (weights[u, v] > 0 && distances[u] + weights[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + weights[u, v];
                        prevNodes[v] = u;
                    }
                }
            }

            // Sonuçları göster
            string result = "Dijkstra Algorithm Results:\n";
            for (int i = 0; i < numNodes; i++)
            {
                if (distances[i] == int.MaxValue)
                    result += $"Node {i}: Cannot be reachable\n";
                else
                    result += $"Node {i}: Shortest Path = {distances[i]}, Prev Node = {prevNodes[i]}\n";
            }

            MessageBox.Show(result);
        }


        // Prim Algoritması
        private void PrimAlgorithm()
        {
            // Check if the weights array is initialized
            if (weights == null)
            {
                MessageBox.Show("You need to create Graph First!");
                return;
            }

            int[] distances = new int[numNodes];
            int[] prevNodes = new int[numNodes];
            bool[] inMST = new bool[numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                distances[i] = int.MaxValue;
                prevNodes[i] = -1;
                inMST[i] = false;
            }

            int startNode = 0;
            distances[startNode] = 0;

            // Prim algoritmasını uygulama
            for (int i = 0; i < numNodes - 1; i++)
            {
                int u = -1;
                for (int j = 0; j < numNodes; j++)
                {
                    if (!inMST[j] && (u == -1 || distances[j] < distances[u]))
                    {
                        u = j;
                    }
                }

                if (distances[u] == int.MaxValue)
                    break;

                inMST[u] = true;

                for (int v = 0; v < numNodes; v++)
                {
                    if (weights[u, v] > 0 && !inMST[v] && weights[u, v] < distances[v])
                    {
                        distances[v] = weights[u, v];
                        prevNodes[v] = u;
                    }
                }
            }

            // Sonuçları göster
            string result = "Prim Algorithm Results:\n";
            for (int i = 0; i < numNodes; i++)
            {
                if (i == startNode)
                {
                    result += $"Node {i}: Start Node\n";
                }
                else if (prevNodes[i] != -1)
                {
                    result += $"Node {i}: Prev Node = {prevNodes[i]}, Weight = {distances[i]}\n";
                }
                else
                {
                    result += $"Node {i}: Cannot be reachable\n";
                }
            }

            MessageBox.Show(result);
        }



        private class UnionFind
        {
            private int[] parent;
            private int[] rank;

            public UnionFind(int size)
            {
                parent = new int[size];
                rank = new int[size];

                for (int i = 0; i < size; i++)
                {
                    parent[i] = i;
                    rank[i] = 0;
                }
            }

            public int Find(int x)
            {
                if (x != parent[x])
                    parent[x] = Find(parent[x]);
                return parent[x];
            }

            public void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX == rootY)
                    return;

                if (rank[rootX] > rank[rootY])
                    parent[rootY] = rootX;
                else if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }




        // Kruskal Algoritması
        private void KruskalAlgorithm()
        {
            // Check if the weights array is initialized
            if (weights == null)
            {
                MessageBox.Show("You need to create Graph firs!");
                return;
            }

            List<(int, int, int)> edges = new List<(int, int, int)>();
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = i + 1; j < numNodes; j++)
                {
                    if (weights != null && weights[i, j] > 0) // Check if the weights array is not null
                    {
                        edges.Add((i, j, weights[i, j]));
                    }
                }
            }

            if (edges.Count == 0)
            {
                MessageBox.Show("Graph has no edges!");
                return;
            }

            edges.Sort((edge1, edge2) => edge1.Item3.CompareTo(edge2.Item3));
            UnionFind unionFind = new UnionFind(numNodes);
            List<(int, int)> minimumSpanningTree = new List<(int, int)>();

            foreach (var edge in edges)
            {
                int node1 = edge.Item1;
                int node2 = edge.Item2;
                int weight = edge.Item3;

                // Eğer bu kenarın düğümleri farklı ağaçlarda ise, ağaca ekleyin ve ağaçları birleştirin
                if (unionFind.Find(node1) != unionFind.Find(node2))
                {
                    minimumSpanningTree.Add((node1, node2));
                    unionFind.Union(node1, node2);
                }
            }

            // Sonuçları göster
            string result = "Minimum Spanning Tree Edges:\n";
            foreach (var edge in minimumSpanningTree)
            {
                result += $"Node {edge.Item1} - Node {edge.Item2}\n";
            }

            MessageBox.Show(result, "Kruskal Algorithm Results");
        }



        private void txtNumNodes_Validating(object sender, CancelEventArgs e)
        {
            // Kullanıcının girdiği değerin geçerli bir sayı olup olmadığını kontrol edin
            if (!int.TryParse(txtNumNodes.Text, out int num))
            {
                // Geçerli bir sayı değilse, hata mesajı gösterin ve işlemi iptal edin
                e.Cancel = true;
                errorProvider.SetError(txtNumNodes, "Please enter a valid number.");
            }
            else
            {
                // Geçerli bir sayıysa, hata mesajını temizleyin
                e.Cancel = false;
                errorProvider.SetError(txtNumNodes, "");

                // TreeView güncelleme
                UpdateTreeView();
            }
        }

        private void InitializeDataGridView()
        {
            // Add columns to the DataGridView
            DataGridViewTextBoxColumn algorithmColumn = new DataGridViewTextBoxColumn();
            algorithmColumn.HeaderText = "Algorithm";
            dataGridView.Columns.Add(algorithmColumn);

            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.HeaderText = "Execution Time";
            dataGridView.Columns.Add(timeColumn);
        }
    }
}
