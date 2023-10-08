
import { Link, useParams } from "react-router-dom";
import {  useDeletePost, useFetchPost } from "../hooks/PostHooks";
import Comments from "../comments/Comments";
import ApiStatus from "../apiStatus";


const PostDetail = () => {
  const { id } = useParams();
  if (!id) throw Error("Post id not found");
  const postId = parseInt(id);

  const { data, status, isSuccess } = useFetchPost(postId);

  const deletePostMutation = useDeletePost();

  if (!isSuccess) return <ApiStatus status={status} />;
  
  if (!data) return <div>Post not found.</div>;

  return (
    <div className="row">
       <div className="col-4">
      <div className="row mt-3">
      <div className="col-4">
            <Link
              className="btn btn-primary w-100"
              to={`/api/Posts/edit/${data.id}`}
            >
              Edit
            </Link>
          </div>
          </div>
          <div className="row mt-3">
          <div className="col-4">
            <button
              className="btn btn-danger w-100"
              onClick={() => {
                if (window.confirm("Are you sure?"))
                deletePostMutation.mutate(data);
              }}
            >
              Delete
            </button>
          </div>
        </div>

        <div className="row mt-3">
      <div className="col-4">
            <Link
              className="btn btn-primary w-100"
              to={`/`}
            >
              Home
            </Link>
          </div>
          </div>

      </div>
      <div className="col-8">
        <div className="row mt-2">
          <h3 className="col-12">{data.title}</h3>
        </div>
        <div className="row">
          <h5 className="col-12">{data.detail}</h5>
        </div>
        <div className="row">
          <h6 className="col-12">Number of Comments: &nbsp;&nbsp;{data.numberOfComment}</h6>
        </div>
        <Comments post={data} />
    
      </div>

     
    </div>
  );
};

export default PostDetail;
