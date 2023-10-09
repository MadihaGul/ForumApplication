import axios, { Axios, AxiosError, AxiosResponse } from "axios"
import { useMutation, useQuery, useQueryClient } from "react-query"
import { Post } from "../types/post"
import config from "../config"
import {PostDetail} from "../types/postdetail"
import { useNavigate } from "react-router-dom"
import Problem from "../types/problem"

// To fetch a post
const useFetchPost = (id: number) => {

    return useQuery<PostDetail, AxiosError>( ["Posts", id], () =>
    axios.get(`${config.baseApiUrl}/api/Posts/${id}`).then
    ((resp) => resp.data)

    )
}

// To add a post
const useAddPost = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
    return useMutation<AxiosResponse, AxiosError, Post>(
      (p) => axios.post(`${config.baseApiUrl}/api/Posts`, p),
      {
        onSuccess: () => {
          console.log("Success: Navigating to list page...");
  
          queryClient.invalidateQueries("Posts");
          nav("/");
        },
      }
    );
  };

// To edit a post
  const useUpdatePost = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
    return useMutation<AxiosResponse, AxiosError<Problem>, Post>(
      (p) => axios.put(`${config.baseApiUrl}/api/Posts/${p.id}`, p),
      {
        onSuccess: (_, post) => {
          queryClient.invalidateQueries("Posts");
         
          nav(`/api/Posts/${post.id}`);
        },
      }
    );
  };

  // To delete a post
  const useDeletePost = () => {
    const queryClient = useQueryClient();
    const nav = useNavigate();
    return useMutation<AxiosResponse, AxiosError, PostDetail>(
      (p) => {
        console.log("${p.id}",p.id);
        return axios.delete(`${config.baseApiUrl}/api/Posts/${p.id}`);
      },
      {
        onSuccess: () => {
          queryClient.invalidateQueries("Posts");
          nav("/");
        },
      }
    );
  };
  
  
export {useFetchPost, useDeletePost, useAddPost, useUpdatePost};