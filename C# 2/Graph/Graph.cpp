//#include <iostream>
//#include <list>
//#include <vector>
//#include <stack>
//using namespace std;
//
//template <typename T=int>
//class Graph
//{
//private:
//	list<list<T>> g;
//
//	list<T>* findVertexList(T const& v) const
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
//		list<T>* l = findVertexList(u);
//		if (l == NULL)
//			return false;
//		list<T> it = l->iteratorBegin(), itp = it++;
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
//		list<T> l;
//		l.toEnd(v);
//		g.toEnd(l);
//	}
//
//	void removeVertex(T const& v)
//	{
//		for(list<list<T> > it = g.iteratorBegin(); it; ++it)
//		{
//			list<T> it2 = (*it).iteratorBegin();
//			if (*it2 == v)
//			{
//				// това е списъкът на върха, който изтриваме
//				list<T> l;
//				list<list<T> > tmp = it;
//				++tmp;
//				g.deleteAt(l, it);
//				it = tmp;
//				// отиваме на следващия връх
//			}
//			if (it)
//			{
//				it2 = (*it).iteratorBegin();
//				// това е друг връх, трябва да изтрием всички входящи във v ребра
//				list<T> it2p = it2++;
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
//	list<T> vertices() const
//	{
//		list<T> vert;
//		for(list<list<T> > it = g.iteratorBegin(); it; ++it)
//		{
//			list<T> it2 = (*it).iteratorBegin();
//			vert.toEnd(*it2);
//		}
//		return vert;
//	}
//
//	bool addEdge(T const& u, T const& v)
//	{
//		list<T>* l = findVertexList(u);
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
//	list<T> successors(T const& v) const
//	{
//		list<T>* l = findVertexList(v);
//		if (l == NULL)
//			return list<T>();
//		list<T> it = l->iteratorBegin();
//		++it;
//		return it;
//	}
//
//	list<list<T> > graph() const
//	{
//		return g.iteratorBegin();
//	}
//
//	//void print() const { g.print(); }
//};


#include <iostream>
#include <queue>
#include <stack>
#include <list>
using namespace std;

typedef list< list<int> > GraphList;

list<int> getChildren(int v, GraphList graph)
{
	for(list< list<int> >::iterator it = graph.begin(); it != graph.end(); ++it)
	{
		list<int> record = *it;

		if (record.front() == v)
		{
			list<int> children;

			for(list<int>::iterator childIt = ++record.begin(); childIt != record.end(); ++childIt)
			{
				children.push_back( *childIt );
			}

			return children;
		}
	}
}

//Depth First Search
void dfs(GraphList g, int v, bool used[])
{
	cout << v << " ";
	used[v] = true;

	list<int> children = getChildren(v, g);

	for(list<int>::iterator it=children.begin(); it != children.end(); ++it)
	{
		int j = *it;
		if ( !used[j] )
		{
			dfs(g, j, used);
		}
	}
}

//Breadth First Search
//Change the queue to stack and you get dfs.
void bfs(GraphList g, queue<int> next, bool used[])
{
	if ( next.empty() )
	{
		return;
	}

	int v = next.front();
	next.pop();

	cout << v << " ";
	used[v] = true;

	list<int> children = getChildren(v, g);
	for(list<int>::iterator it=children.begin(); it != children.end(); ++it)
	{
		int j = *it;

		if ( !used[j] )
		{
			next.push(j);
		}
	}

	bfs(g, next, used);
}

bool member(int x, list<int> l)
{
	
	list<int>::iterator it = l.begin();
	while (it != l.end() && *it != x)
		++it;
	return it != l.end();
}

void DFS(GraphList const& g, int a, list<int>& visited)
{
	cout << " " << a;
	visited.push_back(a);
	list<int> children = getChildren(a,g);
	for(list<int>::iterator it = children.begin();
		it != children.end(); ++it)
		if (!member(*it, visited))
			DFS(g, *it, visited);
}

void BFS(GraphList const& g, int a)
{
	list<int> visited;
	visited.push_back(a);
	list<int>::iterator it = visited.begin();
	while (it != visited.end())
	{
		cout << " " << *it;
		list<int> children = getChildren(*it,g);
		for(list<int>::iterator sit = children.begin(); sit != children.end(); ++sit)
			if (!member(*sit, visited))
				visited.push_back(*sit);
		++it;
	}
}



bool findPath(GraphList g, int a, int b,
			  list<int>& visited)
{
	visited.push_back(a);
	if (a == b)
		return true;
	list<int> children = getChildren(a,g);
	for(list<int>::iterator it = children.begin(); it != children.end(); ++it)
		if (!member(*it, visited) && findPath(g, *it, b, visited))
			return true;
	visited.pop_back();
	return false;
}

void findAllPaths(GraphList g, int a, int b,
				  list<int>& path)
{
	path.push_back(a);
	if (a == b)
	{

		for (list<int>::iterator it = path.begin(); it != path.end(); it++)
		{
			cout<<" "<<*it;
		}
		cout<<endl;
	}
	else
	{
		list<int> children = getChildren(a,g);
		for(list<int>::iterator it = children.begin(); it != children.end(); ++it)
			if (!member(*it, path))
				findAllPaths(g, *it, b, path);
	}
	path.pop_back();
}

bool searchCycle(GraphList g, int a)
{
	list<int> visited;
	visited.push_back(a);
	list<int>::iterator it = visited.begin();
	while (it != visited.end())
	{
		list<int> children = getChildren(*it, g);
		for(list<int>::iterator sit = children.begin(); sit != children.end(); ++sit)
			if (!member(*sit, visited))
				visited.push_back(*sit);
			else
				return true;
		++it;
	}
	return false;
}

int main()
{
	list<int> record1;
	record1.push_back(1);
	record1.push_back(2);
	record1.push_back(3);

	list<int> record2;
	record2.push_back(2);
	record2.push_back(5);

	list<int> record3;
	record3.push_back(3);
	record3.push_back(4);
	record3.push_back(5);

	list<int> record4;
	record4.push_back(4);

	list<int> record5;
	record5.push_back(5);

	GraphList graph;
	graph.push_back(record1);
	graph.push_back(record2);
	graph.push_back(record3);
	graph.push_back(record4);
	graph.push_back(record5);

	const int N = 6;

	bool used[N] = { false };
	cout << "Depth First Search: ";
	dfs(graph, graph.front().front(), used);
	cout << endl;

	for(int i=0; i < N; ++i)
	{
		used[i] = false;
	}
	list<int> l;
	stack<int> st;
	//findPath(graph,1,5,l);
	BFS(graph,1);
	cout<<endl;
	findAllPaths(graph,1,5,l);
	DFS(graph,1,l);
	//queue<int> next;
	//next.push(graph.front().front());
	//cout << "Breadth First Search: ";
	//bfs(graph, next, used);
	cout << endl;
}





