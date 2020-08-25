(defblock :name get-subscriber-message-types :is-top t
	(executor
		:executor-name get-subscriber-message-types
		:verb "handler-types"
		:description "Gets handler types supported by the subscriber."
		:usage-samples (
			"sub types"))

	(end)
)
