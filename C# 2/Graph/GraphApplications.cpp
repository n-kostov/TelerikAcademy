//
//#include <list>
//#include <iostream>
//using namespace std;
//
//template <typename T=int>
//class Graph
//{
//private:
//	LinkedList<LinkedList<T> > g;
//
//	LinkedList<T>* findVertexList(T const& v) const
//	{
//		for(LinkedListIterator<LinkedList<T> > it = g.iteratorBegin();
//			it; ++it)
//		{
//			LinkedListIterator<T> it2 = (*it).iteratorBegin();
//			if (*it2 == v)
//				return &*it;
//		}
//		return NULL;
//	}
//
//	bool findAndRemoveEdge(T const& u, T const& v, bool shouldRemove = true)
//	{
//		LinkedList<T>* l = findVertexList(u);
//		if (l == NULL)
//			return false;
//		LinkedListIterator<T> it = l->iteratorBegin(), itp = it++;
//		while (it && *it != v)
//		{
//			itp = it++;
//		} // !it || *it == v
//		// itp е една стъпка назад от it
//		if (!it)
//			return false;
//		if (shouldRemove)
//		{
//			T w;
//			l->deleteAfter(w, itp);
//		}
//		return true;
//	}
//
//
//public:
//	void addVertex(T const& v)
//	{
//		LinkedList<T> l;
//		l.toEnd(v);
//		g.toEnd(l);
//	}
//
//	void removeVertex(T const& v)
//	{
//		for(LinkedListIterator<LinkedList<T> > it = g.iteratorBegin(); it; ++it)
//		{
//			LinkedListIterator<T> it2 = (*it).iteratorBegin();
//			if (*it2 == v)
//			{
//				// това е списъкът на върха, който изтриваме
//				LinkedList<T> l;
//				LinkedListIterator<LinkedList<T> > tmp = it;
//				++tmp;
//				g.deleteAt(l, it);
//				it = tmp;
//				// отиваме на следващия връх
//			}
//			if (it)
//			{
//				it2 = (*it).iteratorBegin();
//				// това е друг връх, трябва да изтрием всички входящи във v ребра
//				LinkedListIterator<T> it2p = it2++;
//				while(it2 && *it2 != v)
//				{
//					it2p = it2++;
//				}
//				if (it2)
//				{
//					T w;
//					(*it).deleteAfter(w, it2p);
//				}
//			}
//		}
//	}
//
//	bool hasVertex(T const& v) const
//	{
//		return findVertexList(v) != NULL;
//	}
//	LinkedList<T> vertices() const
//	{
//		LinkedList<T> vert;
//		for(LinkedListIterator<LinkedList<T> > it = g.iteratorBegin(); it; ++it)
//		{
//			LinkedListIterator<T> it2 = (*it).iteratorBegin();
//			vert.toEnd(*it2);
//		}
//		return vert;
//	}
//
//	bool addEdge(T const& u, T const& v)
//	{
//		LinkedList<T>* l = findVertexList(u);
//		if (l == NULL)
//			return false;
//		l->toEnd(v); // TODO: check if v is already an edge
//		return true;
//	}
//
//	bool removeEdge(T const& u, T const& v)
//	{
//		return findAndRemoveEdge(u,v);
//	}
//
//	bool hasEdge(T const& u, T const& v)
//	{
//		return findAndRemoveEdge(u,v,false);
//	}
//
//	LinkedListIterator<T> successors(T const& v) const
//	{
//		LinkedList<T>* l = findVertexList(v);
//		if (l == NULL)
//			return LinkedListIterator<T>();
//		LinkedListIterator<T> it = l->iteratorBegin();
//		++it;
//		return it;
//	}
//
//	LinkedListIterator<LinkedList<T> > graph() const
//	{
//		return g.iteratorBegin();
//	}
//
//	void print() const { g.print(); }
//};
//
//
//template <typename T>
//bool member(T const& x, LinkedList<T> const& l)
//{
//	LinkedListIterator<T> it = l.iteratorBegin();
//	while (it && *it != x)
//		++it;
//	return it;
//}
//
//// O(n)
//template <typename T>
//bool member(T const& x, LStack<T> s)
//{
//	T y;
//	if (s.empty())
//		return false;
//	while (s.pop(y) && y != x);
//	return y == x;
//}
//
//// e = |E|
//// v = |V|
//// O(e*v)
//void DFS(Graph<> const& g, int a, LinkedList<>& visited)
//{
//	cout << "Посещаваме " << a << endl;
//	visited.toEnd(a);
//	for(LinkedListIterator<> it = g.successors(a);
//			it; ++it)
//		if (!member(*it, visited))
//			DFS(g, *it, visited);
//}
//
//// O(e*v)
//bool findPath(Graph<> const& g, int a, int b,
//			    LinkedList<>& visited, LStack<>& path)
//{
//	path.push(a);
//	visited.toEnd(a);
//	if (a == b)
//		return true;
//	for(LinkedList<>::I it = g.successors(a); it; ++it)
//		if (!member(*it, visited) && findPath(g, *it, b, visited, path))
//			return true;
//	path.pop(a);
//	return false;
//}
//
////O(v*v!)
//bool findPath2(Graph<> const& g, int a, int b,
//			    LStack<>& path)
//{
//	path.push(a);
//	if (a == b)
//		return true;
//	for(LinkedList<>::I it = g.successors(a); it; ++it)
//		if (!member(*it, path) && findPath2(g, *it, b, path))
//			return true;
//	path.pop(a);
//	return false;
//}
//
////O(v*v!)
//void findAllPaths(Graph<> const& g, int a, int b,
//			    LStack<>& path)
//{
//	path.push(a);
//	if (a == b)
//	{
//		cout << "Намерен път:" << endl;
//		path.print();
//	}
//	else
//	{
//		for(LinkedList<>::I it = g.successors(a); it; ++it)
//			if (!member(*it, path))
//				findAllPaths(g, *it, b, path);
//	}
//	path.pop(a);
//}
//
//
//void BFS(Graph<> const& g, int a)
//{
//	LinkedList<> visited;
//	visited.toEnd(a);
//	LinkedList<>::I it = visited.iteratorBegin();
//	while (it)
//	{
//		cout << "Посещаваме " << *it << endl;
//		for(LinkedList<>::I sit = g.successors(*it); sit; ++sit)
//			if (!member(*sit, visited))
//				visited.toEnd(*sit);
//		++it;
//	}
//}
//
//bool searchCycle(Graph<> const& g, int a)
//{
//	LinkedList<> visited;
//	visited.toEnd(a);
//	LinkedList<>::I it = visited.iteratorBegin();
//	while (it)
//	{
//		for(LinkedList<>::I sit = g.successors(*it); sit; ++sit)
//			if (!member(*sit, visited))
//				visited.toEnd(*sit);
//			else
//				return true;
//		++it;
//	}
//	return false;
//}
//
//
//
//void testGraph()
//{
//	Graph<> g;
//	for(int i = 1; i <= 6; i++)
//		g.addVertex(i);
//	g.addEdge(1,2);
//	g.addEdge(1,3);
//	g.addEdge(2,3);
//	g.addEdge(2,6);
//	g.addEdge(3,4);
//	g.addEdge(4,1);
//	g.addEdge(4,5);
//	g.addEdge(5,3);
//	g.addEdge(6,5);
//	g.addEdge(3,6);
//	g.print();
//	LinkedList<> visited;
//	//DFS(g, 1, visited);
//	// BFS(g, 1);
//	LStack<> path;
//	// g.removeEdge(5, 3);
//	// cout << findPath(g, 1, 5, visited, path) << endl;
//	// cout << findPath(g, 6, 4, visited, path) << endl;
//	// path.print();
//	//findAllPaths(g, 1, 5, path);
//	g.removeEdge(5, 3);
//	cout << findPath2(g, 1, 5, path) << endl;
//	path.print();
//	cout << findPath2(g, 6, 4, path) << endl;
///*	g.vertices().print();
//	g.removeEdge(4,1);
//	g.removeEdge(2,3);
//	g.removeVertex(5);
//	g.print();
//	cout << g.hasEdge(2,6);
//	*/
//}
//
//void testVisitor()
//{
//	Graph<> g;
//	for(int i = 1; i <= 6; i++)
//		g.addVertex(i);
//	g.addEdge(1,2);
//	g.addEdge(1,3);
//	g.addEdge(2,3);
//	g.addEdge(2,6);
//	g.addEdge(3,4);
//	g.addEdge(4,1);
//	g.addEdge(4,5);
//	g.addEdge(5,3);
//	g.addEdge(6,5);
//	g.addEdge(3,6);
//	PrintVisitor<> pv;
//	//	DFS(g, 1, pv);
//	//	BFS(g, 1, pv);
//	FindPathVisitor2<> fpv(5);
//	//	DFS(g, 1, fpv);
//	//fpv.printPath();
////	FindShortestPathDFSVisitor<> dfsv(5);
////	DFS(g, 1, dfsv);
////	dfsv.printShortestPath();
////	FindShortestPathVisitor<> spv(5);
////	BFS(g, 1, spv);
//	SpanningTreeVisitor<> stv;
//	BFS(g, 1, stv);
//	stv.printTree();
//}
//
//struct Vertex
//{
//	int key;
//	double weight;
//	bool operator==(Vertex const& v)
//	{
//		return key == v.key;
//	}
//	bool operator!=(Vertex const& v)
//	{
//		return !(*this == v);
//	}
//};
//
//ostream& operator<<(ostream& os, Vertex const& v)
//{
//	return os << '(' << v.key << ',' << v.weight << ')';
//}
//
//// пример за граф с тегла по върховете и ребрата
//Graph<Vertex> wg;
//
////
////int main()
////{
//////	testGraph();
////	testVisitor();
////}