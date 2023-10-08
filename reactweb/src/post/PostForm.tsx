import React, { useState } from "react";
import { Post } from "../types/post";
import { useNavigate } from "react-router-dom";

type Args = {
  post: Post;
  submitted: (post: Post) => void;
};

const PostForm = ({ post, submitted }: Args) => {
  const [postState, setPostState] = useState({ ...post });

  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    submitted(postState);
  };
  const nav = useNavigate();
  const onCancel: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    
    nav(`/`);
  };

  return (
    <form className="mt-2">
      <div className="form-group">
        <label htmlFor="title">Title</label>
        <input
          type="text"
          className="form-control"
          placeholder="Title"
          value={postState.title}
          onChange={(e) =>
            setPostState({ ...postState, title: e.target.value })
          }
        />
      </div>
      <div className="form-group mt-2">
        <label htmlFor="details">Details</label>
        <input
          type="text"
          className="form-control"
          placeholder="Details"
          value={postState.detail}
          onChange={(e) =>
            setPostState({ ...postState, detail: e.target.value })
          }
        />
      </div>
     
      <button
        className="btn btn-primary mt-2"
        disabled={!postState.title || !postState.detail}
        onClick={onSubmit}
      >
        Post
      </button>
      &nbsp;&nbsp;
      <button
        className="btn btn-primary mt-2"
        
        onClick={onCancel}
      >
        Cancel
      </button>
    </form>
  );
};

export default PostForm;