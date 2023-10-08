import { useParams } from "react-router-dom";
import ApiStatus from "../apiStatus";
import { useFetchPost, useUpdatePost } from "../hooks/PostHooks";
import ValidationSummary from "../ValidationSummary";
import PostForm from "./PostForm";

const PostEdit = () => {
  const { id } = useParams();
  if (!id) throw Error("Need a post id");
  const postId = parseInt(id);

  const { data, status, isSuccess } = useFetchPost(postId);
  const updatePostMutation = useUpdatePost();

  if (!isSuccess) return <ApiStatus status={status} />;

  return (
    <>
      {updatePostMutation.isError && (
        <ValidationSummary error={updatePostMutation.error} />
      )}
      <PostForm
        post={data}
        submitted={(post) => {
          updatePostMutation.mutate(post);
        }}
      />
    </>
  );
};

export default PostEdit;
