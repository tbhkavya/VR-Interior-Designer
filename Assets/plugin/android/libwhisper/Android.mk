LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)
LOCAL_MODULE    := whisper
LOCAL_SRC_FILES := src/whisper.cpp src/ggml.c
LOCAL_C_INCLUDES := $(LOCAL_PATH)/src
include $(BUILD_SHARED_LIBRARY)
