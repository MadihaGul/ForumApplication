import { Comment } from "./../types/comment";
import { useMutation, useQuery, useQueryClient } from "react-query";
import Config from "../config";
import axios, { AxiosError, AxiosResponse } from "axios";
import Problem from "../types/problem";
import { useNavigate } from "react-router-dom";

// To fetch comments
const useFetchComments = (postId: number) => {
  return useQuery<Comment[], AxiosError>(["comments", postId], () =>
    axios
      .get(`${Config.baseApiUrl}/api/posts/${postId}/Comments`)
      .then((resp) => resp.data)
  );
};

// To add comments
const useAddComment = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
  
    return useMutation<AxiosResponse, AxiosError<Problem>, Comment>(
      (comment) =>
        axios.post(`${Config.baseApiUrl}/api/posts/${comment.postId}/Comments`, comment),
      {
        onSuccess: (resp, comment) => {
          queryClient.invalidateQueries(["comments", comment.postId]);
          queryClient.invalidateQueries("Posts");
          // Navigate to the post detail page after successfully adding a comment
          nav(`/api/Posts/${comment.postId}`);
        },
      }
    );
  };
  

export { useFetchComments, useAddComment };
