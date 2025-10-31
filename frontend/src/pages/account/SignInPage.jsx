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
import { NavLink } from "react-router-dom";
function SignInPage() {
  const [showPassword, setShowPassword] = useState(false);

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

  const onSubmit = (data) => {
    console.log(data);
  };

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  };
  return (
    <div className="w-screen h-screen bg-gray-100 flex flex-col items-center">
      <Card className="max-w-[1440px] w-full m-5">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="flex justify-between items-center p-4">
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
              <Button type="submit" variant="contained">
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
