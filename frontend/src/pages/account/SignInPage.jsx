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
import { SignInSchema } from "../../Schema/AccountSchema";
import { Visibility, VisibilityOff } from "@mui/icons-material";

import InputAdornment from "@mui/material/InputAdornment";
import { useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { useMutation } from "@tanstack/react-query";
import { signInUser } from "../../Mutations/UserMutations";
import { useSnackbar } from "notistack";
function SignInPage() {
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();
  const [showPassword, setShowPassword] = useState(false);

  const mutation = useMutation({
    mutationFn: signInUser,
    onSuccess: () => {
      enqueueSnackbar("Sign In Successful!", { variant: "success" });
      navigate("/tasks");
    },
    onError: (error, variables) => {
      enqueueSnackbar(`Sign In Failed: ${error.ErrorMessage}`, {
        variant: "error",
      });
    },
  });

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(SignInSchema),
    defaultValues: {
      username: "",
      password: "",
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
          <div className="flex justify-between items-center p-8">
            <div className="flex flex-col items-start">
              <Typography variant="h6">Sign In Page</Typography>
              <Typography variant="subtitle1">
                No account? <NavLink to="/sign-up">Sign Up</NavLink>
              </Typography>
            </div>
            <div className="flex gap-4 items-start">
              <Controller
                name="username"
                control={control}
                rules={{ required: true, maxLength: 50 }}
                render={({ field }) => (
                  <TextField
                    size="small"
                    label="Username"
                    placeholder="Username"
                    variant="outlined"
                    helperText={errors.username?.message}
                    {...field}
                  />
                )}
              />
              <Controller
                name="password"
                control={control}
                rules={{ required: true, maxLength: 50 }}
                render={({ field }) => (
                  <FormControl {...field} size="small" variant="outlined">
                    <InputLabel htmlFor="outlined-adornment-password">
                      Password
                    </InputLabel>
                    <OutlinedInput
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
                            {showPassword ? <VisibilityOff /> : <Visibility />}
                          </IconButton>
                        </InputAdornment>
                      }
                      label="Password"
                    />
                    <FormHelperText>{errors.password?.message}</FormHelperText>
                  </FormControl>
                )}
              />
              <Button
                loading={mutation.isPending}
                type="submit"
                variant="contained"
              >
                Sign In
              </Button>
            </div>
          </div>
        </form>
      </Card>
    </div>
  );
}

export default SignInPage;
