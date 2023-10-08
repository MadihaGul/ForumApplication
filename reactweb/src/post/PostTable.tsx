import React, { useState, useEffect, useMemo } from "react";
import { Post } from "../types/post";
import config from "../config";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

const PostTable = () => {
  const [posts, setPosts] = useState<Post[]>([]);

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const rsp = await fetch(`${config.baseApiUrl}/api/Posts`);
        const postsData = await rsp.json();
        setPosts(postsData);
      } catch (error) {
        console.error("Error fetching posts:", error);
      }
    };

    fetchPosts();
  }, []); // The empty dependency array ensures that this effect runs once when the component mounts

  const columns = [
    { key: "title", label: "Title" },
    { key: "detail", label: "Detail" },
    { key: "createdTime", label: "Time" },
  ];

  return (
    <div>      
      <SortableTable data={posts} columns={columns} />
    </div>
  );
};

interface SortableTableProps {
  data: Post[];
  columns: { key: string; label: string }[];
}

const SortableTable: React.FC<SortableTableProps> = ({ data, columns }) => {
    const [sortConfig, setSortConfig] = useState<{ key: string; direction: string }>({ key: "", direction: "" });
  
    const nav = useNavigate();
    const sortedData = useMemo(() => {
      let sortableData = [...data];
      if (sortConfig.key) {
        sortableData.sort((a, b) => {
          // Use type assertion to access properties with string keys safely
          const aValue = a[sortConfig.key as keyof Post];
          const bValue = b[sortConfig.key as keyof Post];
  
          if (aValue < bValue) {
            return sortConfig.direction === "ascending" ? -1 : 1;
          }
          if (aValue > bValue) {
            return sortConfig.direction === "ascending" ? 1 : -1;
          }
          return 0;
        });
      }
      return sortableData;
  }, [data, sortConfig]);

  const requestSort = (key: string) => {
    let direction = "ascending";
    if (sortConfig.key === key && sortConfig.direction === "ascending") {
      direction = "descending";
    }
    setSortConfig({ key, direction });
  };
  let options: Intl.DateTimeFormatOptions = {
    day: "numeric", month: "numeric", year: "numeric",
    hour: "2-digit", minute: "2-digit"
  }
  return (
    
    <div>
      <table className="table table-hover">
      <thead>
        <tr>
          {columns.map((column) => (
            <th key={column.key}>
              <button
                type="button"
                onClick={() => requestSort(column.key)}
                className={
                  sortConfig.key === column.key
                    ? sortConfig.direction
                    : undefined
                }
              >
                {column.label}
              </button>
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {sortedData.map((item) => (
          <tr key={item.id} onClick={() => nav(`/api/Posts/${item.id}`)}>
            {columns.map((column) => (
              <td key={column.key}>           
                {column.key === "createdTime" ? (
                (() => {
                    const createdTime = item[column.key as keyof Post];
                    return (
                    <td key={column.key}>
                        {new Date(createdTime).toLocaleDateString("en-GB", options)}
                    </td>
                    );
                })()
                ) : (
                <td key={column.key}>{(item as any)[column.key].substring(0, 100)}</td>
                )}

              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
    <Link className="btn btn-primary" to="/api/Posts/add">
      Add Post
    </Link>
    </div>
  );
};

export default PostTable;
