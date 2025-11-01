import {
  Card,
  Typography,
  Button,
  TextField,
  FormHelperText,
} from "@mui/material";
import { Controller, useForm } from "react-hook-form";
import {
  FormControl,
  InputLabel,
  OutlinedInput,
  IconButton,
} from "@mui/material";

import { yupResolver } from "@hookform/resolvers/yup";
import { SignInSchema, SignUpSchema } from "../../Schema/AccountSchema";
import { Visibility, VisibilityOff } from "@mui/icons-material";

import InputAdornment from "@mui/material/InputAdornment";
import { useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { useSnackbar } from "notistack";
import { signUpUser } from "../../Mutations/UserMutations";
import { useMutation } from "@tanstack/react-query";
function SignUpPage() {
  const navigate = useNavigate();
  const { enqueueSnackbar } = useSnackbar();

  const [showPassword, setShowPassword] = useState(false);

  const mutation = useMutation({
    mutationFn: signUpUser,
    onSuccess: () => {
      enqueueSnackbar("Sign Up Successful!", { variant: "success" });
      navigate("/");
    },
    onError: (error) => {
      enqueueSnackbar("Sign Up Failed!", { variant: "error" });
    },
  });

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(SignUpSchema),
    defaultValues: {
      username: "",
      password: "",
      name: "",
      email: "",
    },
  });

  const onSubmit = async (data) => {
    await mutation.mutateAsync(data);
  };

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  };
  return (
    <div className="w-screen h-screen bg-gray-100 flex flex-col items-center">
      <Card className="max-w-[1440px] w-full m-10">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="flex justify-between  p-8">
            <div className="flex flex-col items-start w-1/2">
              <Typography variant="h6">Sign Up</Typography>
              <Typography variant="subtitle1">
                Already have an account? <NavLink to="/">Sign In</NavLink>
              </Typography>
            </div>
            <div className="flex gap-4 flex-col items-start w-1/2">
              <div className="flex flex-col m-auto gap-4 w-[300px]">
                <Controller
                  name="username"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      autoComplete="username"
                      fullWidth
                      size="small"
                      label="Username"
                      placeholder="Enter your username"
                      variant="outlined"
                      helperText={errors.username?.message}
                      {...field}
                    />
                  )}
                />
                <Controller
                  name="name"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      fullWidth
                      autoComplete="name"
                      size="small"
                      label="Name"
                      placeholder="Enter your full name"
                      variant="outlined"
                      helperText={errors.name?.message}
                      {...field}
                    />
                  )}
                />
                <Controller
                  name="email"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      fullWidth
                      autoComplete="email"
                      size="small"
                      label="Email"
                      placeholder="Enter your email"
                      variant="outlined"
                      helperText={errors.email?.message}
                      {...field}
                    />
                  )}
                />
                <Controller
                  name="password"
                  control={control}
                  render={({ field }) => (
                    <FormControl
                      fullWidth
                      {...field}
                      size="small"
                      variant="outlined"
                      aria-autocomplete="list"
                    >
                      <InputLabel htmlFor="outlined-adornment-password">
                        Password
                      </InputLabel>
                      <OutlinedInput
                        autoComplete="new-password"
                        id="outlined-adornment-password"
                        type={showPassword ? "text" : "password"}
                        endAdornment={
                          <InputAdornment position="end">
                            <IconButton
                              aria-label={
                                showPassword
                                  ? "hide the password"
                                  : "display the password"
                              }
                              onClick={handleClickShowPassword}
                              edge="end"
                            >
                              {showPassword ? (
                                <VisibilityOff />
                              ) : (
                                <Visibility />
                              )}
                            </IconButton>
                          </InputAdornment>
                        }
                        label="Password"
                      />
                      <FormHelperText>
                        {errors.password?.message}
                      </FormHelperText>
                    </FormControl>
                  )}
                />
                <Button
                  loading={mutation.isPending}
                  type="submit"
                  variant="contained"
                >
                  Sign Up
                </Button>
              </div>
            </div>
          </div>
        </form>
      </Card>
    </div>
  );
}

export default SignUpPage;
