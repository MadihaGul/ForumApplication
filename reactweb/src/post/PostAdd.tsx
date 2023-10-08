import { useAddPost } from "../hooks/PostHooks";
import { Post } from "../types/post";

import PostForm from "./PostForm";

const PostAdd = () => {
  const addPostMutation = useAddPost();

  const post : Post = {
    title: "",
    detail: "",
    id: 0,
    updatedTime : new Date(),
    createdTime: new Date(),
  };

  return (
    <>
     
      <PostForm
        post={post}
        submitted={(post) => addPostMutation.mutate(post)}
      />
    </>
  );
};

export default PostAdd;
