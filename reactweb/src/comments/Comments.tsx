// To display list/table of comments
import { useState } from "react";

import { useAddComment, useFetchComments } from "../hooks/CommentHooks";
import { Comment } from "../types/comment";
import { Post } from "../types/post";

type Args = {
  post: Post;
};

const Comments = ({ post }: Args) => {
  const { data, status, isSuccess } = useFetchComments(post.id);
  const addCommentMutation = useAddComment();

  const emptyComment = {
    id: 0,
    postId: post.id,
    text: "",
    createdTime:new Date(),
    updatedTime:new Date()
  };
  const [comment, setComment] = useState<Comment>(emptyComment);

  const onCommentSubmitClick = () => {
    addCommentMutation.mutate(comment);
    setComment(emptyComment);
  };
  let options: Intl.DateTimeFormatOptions = {
    day: "numeric", month: "numeric", year: "numeric",
    hour: "2-digit", minute: "2-digit"
  }
  return (
    <>
      <div className="row mt-4">
        <div className="col-12">
          <table className="table table-sm">
            <thead>
              <tr>
                <th>Comments</th>
                
              </tr>
            </thead>
            <tbody>
              {data &&
                data.map((c) => (
                  <tr key={c.id}>
                    <td>{c.text} &nbsp;&nbsp;
                    {new Date(c.createdTime).toLocaleDateString("en-GB", options)}                    
                    </td>
                   
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
      <div className="row">
        
        <div className="col-8">
          <input
            id="text"
            className="h-100"
            type="string"
            value={comment.text}
            onChange={(e) =>
              setComment({ ...comment, text: e.target.value })
            }
            placeholder="Comment"
          ></input>
        </div>
        <div className="col-2">
          <button
            className="btn btn-primary"
            disabled={!comment.text }
            onClick={() => onCommentSubmitClick()}
          >
            Add
          </button>
        </div>
      </div>
    </>
  );
};

export default Comments;
